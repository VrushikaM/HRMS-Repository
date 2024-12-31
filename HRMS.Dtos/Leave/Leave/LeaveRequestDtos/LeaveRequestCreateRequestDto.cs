using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Dtos.Leave.Leave.LeaveRequestDtos
{
    public class LeaveRequestCreateRequestDto
    {
        public int User_ID { get; set; } // ID of the user who created the leave request
        public int EmployeeID { get; set; } // ID of the employee making the request
        public int LeaveTypeID { get; set; } // Type of leave requested
        public DateTime StartDate { get; set; } // Start date of the leave
        public DateTime EndDate { get; set; } // End date of the leave
        public int TotalDays { get; set; } // Total days of leave requested
        public string? Reason { get; set; } // Optional reason for leave
        public DateTime RequestDate { get; set; } = DateTime.Now; // Request date
        public string Status { get; set; } = "Pending"; // Default status
        public int? ApprovedBy { get; set; } // Approver's ID
        public string? Remarks { get; set; } // Optional remarks from approver
        public bool IsActive { get; set; } = false; // Default is inactive
        public bool IsDelete { get; set; } = false; // Default is not deleted
        public int CreatedBy { get; set; } // ID of the user creating the request
    }
}
