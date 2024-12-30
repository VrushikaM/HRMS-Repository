using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.User.Roles.RolesRequestEntities
{
    public class RolesCreateRequestEntity
    {
        public string RoleName { get; set; } = string.Empty;

        public int PermissionGroupId { get; set; }

        public int CreatedBy { get; set; }

        public bool IsActive { get; set; }

       
    }
}
