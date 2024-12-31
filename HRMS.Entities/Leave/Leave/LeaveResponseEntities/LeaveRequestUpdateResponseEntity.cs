using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.Leave.Leave.LeaveResponseEntities
{
    public class LeaveRequestUpdateResponseEntity
    {
        public int LeaveRequestID { get; set; } // Unique identifier for the request
        public int UserId { get; set; } // User who created/associated with the request
        public int EmployeeID { get; set; } // Employee requesting the leave
        public int LeaveTypeID { get; set; } // Type of leave
        public DateTime StartDate { get; set; } // Updated start date
        public DateTime EndDate { get; set; } // Updated end date
        public int TotalDays { get; set; } // Updated total days
        public string Reason { get; set; } = string.Empty; // Updated reason for leave
        public string Status { get; set; } = "Pending"; // Updated status
        public int? ApprovedBy { get; set; } // Updated manager approval
        public string Remarks { get; set; } = string.Empty; // Updated comments
        public int? UpdatedBy { get; set; } // User who updated the record
        public DateTime UpdatedAt { get; set; } // Timestamp of the last update
        public bool IsActive { get; set; } // Updated active status
        public bool IsDelete { get; set; } // Updated logical deletion flag
    }
}
