using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Utility.Helpers.SqlHelpers.Leave
{
    public class LeaveRequestStoredProcedure
    {
        public const String GetLeaves = "spLeaveRequestGetAll";
        public const String GetLeave = "spLeaveRequestGet";
        public const String CreateLeave = "spLeaveRequestAdd";
        public const String UpdateLeave = "spLeaveRequestUpdate";
        public const String DeleteLeave = "spLeaveRequestDelete";
    }
}
