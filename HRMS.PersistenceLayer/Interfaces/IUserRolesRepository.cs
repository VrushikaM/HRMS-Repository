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
    public interface IUserRolesRepository
    {
        Task<IEnumerable<UserRolesReadResponseEntity>> GetAllUserRoles();

        Task<UserRolesReadResponseEntity?> GetUserRolesById(int? roleId);

        Task<UserRolesCreateResponseEntity> CreateUserRole(UserRolesCreateRequestEntity roles);

        Task<UserRolesUpdateResponseEntity?> UpdateUserRoles(UserRolesUpdateRequestEntity roles);

        Task<int> DeleteUserRoles(UserRolesDeleteRequestEntity roles);

    }
}
