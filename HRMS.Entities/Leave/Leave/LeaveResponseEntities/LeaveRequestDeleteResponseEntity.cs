using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.Leave.Leave.LeaveResponseEntities
{
    public class LeaveRequestDeleteResponseEntity
    {
        public int LeaveRequestID { get; set; } // Unique identifier for the request
        public int? DeletedBy { get; set; } // User who deleted the record
        public DateTime? DeletedDate { get; set; } // Date and time when the record was deleted
    }
}

