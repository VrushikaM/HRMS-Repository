using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Utility.Helpers.SqlHelpers.User
{
    public static class RolesStoredProcedure
    {
        public const string GetRoles = "spRolesGetAll";

        public const string GetRoleById = "spRolesGet";

        public const string CreateRoles = "spRolesAdd";

        public const string UpdateRoles = "spRolesUpdate";

        public const string DeleteRoles = "spRolesDelete";

    }
}
