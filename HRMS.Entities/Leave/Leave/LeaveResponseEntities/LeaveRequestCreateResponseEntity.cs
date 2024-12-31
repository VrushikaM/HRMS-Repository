using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.Leave.Leave.LeaveResponseEntities
{
    public  class LeaveRequestCreateResponseEntity
    {
        public int LeaveRequestID { get; set; } // Unique identifier for the request
        public int UserId { get; set; } // User who created/associated with the request
        public int EmployeeID { get; set; } // Employee requesting the leave
        public int LeaveTypeID { get; set; } // Type of leave
        public DateTime StartDate { get; set; } // Start date of leave
        public DateTime EndDate { get; set; } // End date of leave
        public int TotalDays { get; set; } // Total days of leave
        public string Reason { get; set; } = string.Empty; // Reason for leave
        public DateTime RequestDate { get; set; } // Date when the leave was requested
        public string Status { get; set; } = "Pending"; // Status: Pending, Approved, Rejected
        public int? ApprovedBy { get; set; } // Manager who approved/rejected the leave
        public string Remarks { get; set; } = string.Empty; // Comments from the approver
        public bool IsActive { get; set; } // Indicates active status
        public bool IsDelete { get; set; } // Logical deletion flag
    }
}
