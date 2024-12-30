using HRMS.Entities.User.Roles.RolesRequestEntities;
using HRMS.Entities.User.Roles.RolesResponseEntities;
using HRMS.Entities.User.User.UserRequestEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.PersistenceLayer.Interfaces
{
    public interface IRolesRepository
    {
        Task<IEnumerable<RolesReadResponseEntity>> GetAllUserRoles();

        Task<RolesReadResponseEntity?> GetUserRolesById(int? roleId);

        Task<RolesCreateResponseEntity> CreateUserRole(RolesCreateRequestEntity roles);

        Task<RolesUpdateResponseEntity?> UpdateUserRoles(RolesUpdateRequestEntity roles);

        Task<int> DeleteUserRoles(RolesDeleteRequestEntity roles);

    }
}
