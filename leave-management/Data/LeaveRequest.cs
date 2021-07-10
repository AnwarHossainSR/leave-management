﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class LeaveRequest
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("RequestingEmployee")]
        public string RequestingEmployeeId { get; set; }
        public Employee RequestingEmployee { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey("LeaveType")]
        public int LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }
        
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; }
        public DateTime DateActioned { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
        [ForeignKey("ApprovedBy")]
        public string ApprovedById { get; set; }
        public Employee ApprovedBy { get; set; }
        
    }
}
