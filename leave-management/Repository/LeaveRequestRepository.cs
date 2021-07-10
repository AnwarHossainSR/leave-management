using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveRequestRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(LeaveRequest entity)
        {
            await _db.LeaveRequests.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(LeaveRequest entity)
        {
            _db.LeaveRequests.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<LeaveRequest>> FindAll()
        {
            var LeaveHistorys = await _db.LeaveRequests
                .Include(q => q.RequestingEmployee)
                .Include(q => q.LeaveType)
                .Include(q => q.ApprovedBy)
                .ToListAsync();
            return LeaveHistorys;
        }

        //var LeaveAllocation = _db.LeaveAllocations
        //        .Include(q => q.LeaveType)
        //        .Include(q => q.Employee)
        //        .FirstOrDefault(q => q.Id == id);

        public async Task<LeaveRequest> FindById(int id)
        {
            var LeaveRequest = await _db.LeaveRequests
                .Include(q => q.RequestingEmployee)
                .Include(q => q.LeaveType)
                .Include(q => q.ApprovedBy)
                .FirstOrDefaultAsync(q => q.Id == id);
            return LeaveRequest;
        }

        public async Task<ICollection<LeaveRequest>> GetLeaveRequestsByEmployee(string employeeid)
        {
            var leaveRequests = await FindAll();
            return leaveRequests.Where(q => q.RequestingEmployeeId == employeeid)
                .ToList();
        }

        public async Task<bool> isExists(int id)
        {
            var exists = await _db.LeaveTypes.AnyAsync(q => q.Id == id);
            return exists;
        }
        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(LeaveRequest entity)
        {
            _db.LeaveRequests.Update(entity);
            return await Save();
        }
    }
}
