using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.Leave.Leave.LeaveRequestEntities
{
    public class LeaveRequestDeleteRequestEntity
    {
        public int LeaveRequestID { get; set; } // Primary key of the leave request
        public int? DeletedBy { get; set; } // User ID of the person performing the delete
        public DateTime? DeletedDate { get; set; } = DateTime.Now; // Timestamp of the deletion
    }
}
