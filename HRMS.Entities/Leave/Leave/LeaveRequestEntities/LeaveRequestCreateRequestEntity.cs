using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.Leave.Leave.LeaveRequestEntities
{
    public class LeaveRequestCreateRequestEntity
    {
        public int LeaveRequestID { get; set; } // Primary key, auto-generated in DB
        public int UserId { get; set; } // Foreign key, references User(User_ID)
        public int EmployeeID { get; set; } // Foreign key, references Employee(EmployeeID)
        public int LeaveTypeID { get; set; } // Foreign key, references LeaveType(LeaveTypeID)
        public DateTime StartDate { get; set; } // Not null
        public DateTime EndDate { get; set; } // Not null
        public int TotalDays { get; set; } // Must be greater than 0
        public string Reason { get; set; } = string.Empty; // Optional, max length defined by database
        public DateTime RequestDate { get; set; } = DateTime.Now; // Default GETDATE()
        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected
        public int? ApprovedBy { get; set; } // Foreign key, references Employee(EmployeeID), nullable
        public string Remarks { get; set; } = string.Empty; // Optional
        public int? DeletedBy { get; set; } // Foreign key, references User(User_ID), nullable
        public int? UpdatedBy { get; set; } // Nullable
        public DateTime? DeletedDate { get; set; } // Nullable
        public DateTime UpdatedAt { get; set; } = DateTime.Now; // Default GETDATE()
        public bool IsActive { get; set; } = false; // Default 0
        public bool IsDelete { get; set; } = false; // Default 0
    }
}
