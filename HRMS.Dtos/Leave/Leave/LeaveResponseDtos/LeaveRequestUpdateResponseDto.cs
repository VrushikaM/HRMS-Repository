using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Dtos.Leave.Leave.LeaveResponseDtos
{
    public class LeaveRequestUpdateResponseDto
    {
        public int LeaveRequestID { get; set; }
        public int User_ID { get; set; }
        public int EmployeeID { get; set; }
        public int LeaveTypeID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalDays { get; set; }
        public string? Reason { get; set; }
        public DateTime RequestDate { get; set; }
        public string ?Status { get; set; }
        public int? ApprovedBy { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime UpdatedAt { get; set; } // Timestamp when the record was last updated
        public string Message { get; set; } = "Leave request updated successfully."; // Success message
        public bool Success { get; set; } = true; // Indicates if the operation was successful
    }
}

