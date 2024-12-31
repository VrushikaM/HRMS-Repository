using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.Leave.Leave.LeaveRequestEntities
{
    public class LeaveRequestUpdateRequestEntity
    {
        public int LeaveRequestID { get; set; } // Primary key
        public int UserId { get; set; } // Foreign key, references User(User_ID)
        public int EmployeeID { get; set; } // Foreign key, references Employee(EmployeeID)
        public int LeaveTypeID { get; set; } // Foreign key, references LeaveType(LeaveTypeID)
        public DateTime StartDate { get; set; } // Updated start date
        public DateTime EndDate { get; set; } // Updated end date
        public int TotalDays { get; set; } // Must remain > 0
        public string Reason { get; set; } = string.Empty; // Updated reason, if applicable
        public string Status { get; set; } = "Pending"; // Updated status: Pending, Approved, Rejected
        public int? ApprovedBy { get; set; } // Updated approver, nullable
        public string Remarks { get; set; } = string.Empty; // Updated remarks
        public int? UpdatedBy { get; set; } // ID of the user making the update
        public DateTime UpdatedAt { get; set; } = DateTime.Now; // Timestamp of the update
        public bool IsActive { get; set; } // Updated active status
        public bool IsDelete { get; set; } // Updated logical deletion flag
    }
}
