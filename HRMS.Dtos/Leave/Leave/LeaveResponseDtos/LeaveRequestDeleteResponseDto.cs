using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Dtos.Leave.Leave.LeaveResponseDtos
{
    public class LeaveRequestDeleteResponseDto
    {
        public int LeaveRequestID { get; set; }
        public string Message { get; set; } = "Leave request deleted successfully."; // Success message
        public bool Success { get; set; } = true; // Indicates if the operation was successful
        public DateTime DeletedAt { get; set; } // Timestamp of when the leave request was marked as deleted
    }
}

