using leave_management.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Contracts
{
    public interface ILeaveTypeRepository : IRepositoryBase<LeaveType>
    {
        //Employee GetEmployeesByLeaveType(int id);
    }
}
