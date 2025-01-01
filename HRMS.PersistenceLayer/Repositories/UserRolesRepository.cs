using Dapper;
using HRMS.Entities.User.User.UserResponseEntities;
using HRMS.Entities.User.UserRoles.UserRolesRequestEntities;
using HRMS.Entities.User.UserRoles.UserRolesResponseEntities;
using HRMS.PersistenceLayer.Interfaces;
using HRMS.Utility.Helpers.SqlHelpers.User;
using System.Data;


namespace HRMS.PersistenceLayer.Repositories
{
    public class UserRolesRepository : IUserRolesRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRolesRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<UserRolesReadResponseEntity>> GetUserRoles()
        {
            var roles = await _dbConnection.QueryAsync<UserRolesReadResponseEntity>(UserRolesStoredProcedure.GetUserRoles, commandType: CommandType.StoredProcedure);
            return roles;
        }

        public async Task<UserRolesReadResponseEntity?> GetUserRoleById(int? rolesId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@RoleId", rolesId);

            var roles = await _dbConnection.QueryFirstOrDefaultAsync<UserRolesReadResponseEntity>(UserRolesStoredProcedure.GetUserRoleById, parameters, commandType: CommandType.StoredProcedure);

            return roles;
        }

        public async Task<UserRolesCreateResponseEntity> CreateUserRole(UserRolesCreateRequestEntity roles)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@RoleId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@RoleName", roles.RoleName);
            parameters.Add("@PermissionGroupId", roles.PermissionGroupId);
            parameters.Add("@CreatedBy", roles.CreatedBy);
            parameters.Add("@IsActive", roles.IsActive);

            var result = await _dbConnection.QuerySingleOrDefaultAsync<dynamic>(UserRolesStoredProcedure.CreateUserRoles, parameters, commandType: CommandType.StoredProcedure);

            var roleId = parameters.Get<int>("@RoleId");

            var createdRole = new UserRolesCreateResponseEntity
            {
                RoleId = roleId,
                RoleName = roles.RoleName,
                PermissionGroupId = roles.PermissionGroupId,
                CreatedBy = roles.CreatedBy,
                CreatedAt = DateTime.Now,
                UpdatedBy = result?.UpdatedBy,
                UpdatedAt = DateTime.Now,
                IsActive = roles.IsActive,
                IsDelete = result?.IsDelete
            };

            return createdRole;
        }

        public async Task<UserRolesUpdateResponseEntity?> UpdateUserRoles(UserRolesUpdateRequestEntity roles)
        {
            var paramters = new DynamicParameters();
            paramters.Add("@RoleId", roles.RoleId);
            paramters.Add("@RoleName", roles.RoleName);
            paramters.Add("@PermissionGroupId", roles.PermissionGroupId);
            paramters.Add("@UpdatedBy", roles.UpdatedBy);
            paramters.Add("@IsActive", roles.IsActive);
            paramters.Add("@IsDelete", roles.IsDelete);

            var result = await _dbConnection.QuerySingleOrDefaultAsync<UserRolesUpdateResponseEntity>(UserRolesStoredProcedure.UpdateUserRoles, paramters, commandType: CommandType.StoredProcedure);

            if (result == null || result.RoleId == -1)
            {
                return null;
            }

            var updateUserRoles = new UserRolesUpdateResponseEntity
            {
                RoleId = roles.RoleId,
                RoleName = roles.RoleName,
                PermissionGroupId = roles.PermissionGroupId,
                CreatedBy = result.CreatedBy,
                CreatedAt = result.CreatedAt,
                UpdatedBy = roles.UpdatedBy,
                UpdatedAt = DateTime.Now,
                IsActive = roles.IsActive,
                IsDelete = roles.IsDelete
            };
            return updateUserRoles;
        }

        public async Task<int> DeleteUserRoles(UserRolesDeleteRequestEntity roles)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@RoleId", roles.RoleId);

            var result = await _dbConnection.ExecuteScalarAsync<int>(UserRolesStoredProcedure.DeleteUserRoles, parameters, commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
