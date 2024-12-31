﻿using HRMS.Entities.User.UserRoles.UserRolesRequestEntities;
using HRMS.Entities.User.UserRoles.UserRolesResponseEntities;

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
