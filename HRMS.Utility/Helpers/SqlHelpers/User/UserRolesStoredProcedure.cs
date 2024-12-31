using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Utility.Helpers.SqlHelpers.User
{
    public static class UserRolesStoredProcedure
    {
        public const string GetUserRoles = "spUserRolesGetAll";

        public const string GetUserRoleById = "spUserRolesGet";

        public const string CreateUserRoles = "spUserRolesAdd";

        public const string UpdateUserRoles = "spUserRolesUpdate";

        public const string DeleteUserRoles = "spUserRolesDelete";

    }
}
