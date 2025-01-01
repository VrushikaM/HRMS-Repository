using HRMS.Entities.User.UserRoles.UserRolesRequestEntities;
using HRMS.Entities.User.UserRoles.UserRolesResponseEntities;
using HRMS.Entities.User.UserRolesMapping.UserRolesMappingRequestEntities;
using HRMS.Entities.User.UserRolesMapping.UserRolesMappingResponseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.PersistenceLayer.Interfaces
{
    public interface IUserRolesMappingRepository
    {
        Task<UserRolesMappingCreateResponseEntity> CreateUserRoleMapping(UserRolesMappingCreateRequestEntity rolesMapping);
    }
}
