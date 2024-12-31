using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Dtos.Leave.Leave.LeaveRequestDtos
{
    public class LeaveRequestDeleteRequestDto
    {
        public int LeaveRequestID { get; set; } // Primary key
        public int DeletedBy { get; set; } // ID of the user deleting the record
        public DateTime DeletedDate { get; set; } = DateTime.Now; // Timestamp for deletion
    }
}
