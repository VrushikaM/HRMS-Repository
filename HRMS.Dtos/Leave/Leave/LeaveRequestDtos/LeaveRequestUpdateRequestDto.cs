using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Dtos.Leave.Leave.LeaveRequestDtos
{
    public class LeaveRequestUpdateRequestDto
    {
        public int LeaveRequestID { get; set; } // Primary key
        public int? User_ID { get; set; } // ID of the user who owns the request
        public int? EmployeeID { get; set; } // ID of the employee making the request
        public int? LeaveTypeID { get; set; } // Type of leave requested
        public DateTime? StartDate { get; set; } // Start date of the leave
        public DateTime? EndDate { get; set; } // End date of the leave
        public int? TotalDays { get; set; } // Total days of leave requested
        public string? Reason { get; set; } // Optional reason for leave
        public string? Status { get; set; } // Updated status
        public int? ApprovedBy { get; set; } // Approver's ID
        public string? Remarks { get; set; } // Optional remarks from approver
        public int UpdatedBy { get; set; } // ID of the user updating the request
        public bool? IsActive { get; set; } // Active status
        public bool? IsDelete { get; set; } // Deletion flag
        public DateTime? UpdatedAt { get; set; } = DateTime.Now; // Last updated timestamp
    }
}
