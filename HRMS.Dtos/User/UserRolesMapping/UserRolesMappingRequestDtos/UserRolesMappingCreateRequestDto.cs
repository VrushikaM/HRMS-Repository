using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Dtos.User.UserRolesMapping.UserRolesMappingRequestDtos
{
    public class UserRolesMappingCreateRequestDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int CreatedBy { get; set; }
    }
}
