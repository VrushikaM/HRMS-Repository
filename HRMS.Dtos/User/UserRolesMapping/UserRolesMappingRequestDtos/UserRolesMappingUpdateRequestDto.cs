using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Dtos.User.UserRolesMapping.UserRolesMappingRequestDtos
{
    public class UserRolesMappingUpdateRequestDto
    {
        public int UserRoleMappingId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsActive { get; set; } 
        public bool IsDelete { get; set; } 
    }
}
