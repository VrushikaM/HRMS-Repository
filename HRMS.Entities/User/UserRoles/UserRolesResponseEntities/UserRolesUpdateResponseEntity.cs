using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.User.Roles.RolesResponseEntities
{
    public class UserRolesUpdateResponseEntity
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; } = string.Empty;

        public int PermissionGroupId { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }
    }
}
