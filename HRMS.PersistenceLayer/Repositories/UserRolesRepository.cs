    using Dapper;
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

        public async Task<IEnumerable<UserRolesReadResponseEntity>> GetAllUserRoles()
        {
            var roles = await _dbConnection.QueryAsync<UserRolesReadResponseEntity>(UserRolesStoredProcedure.GetUserRoles, commandType: CommandType.StoredProcedure);
            return roles;
        }

        public async Task<UserRolesReadResponseEntity?> GetUserRolesById(int? rolesId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserRoleId", rolesId);

            var roles = await _dbConnection.QueryFirstOrDefaultAsync<UserRolesReadResponseEntity>(UserRolesStoredProcedure.GetUserRoleById, parameters, commandType: CommandType.StoredProcedure);

            return roles;
        }

        public async Task<UserRolesCreateResponseEntity> CreateUserRole(UserRolesCreateRequestEntity roles)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserRoleId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@UserRoleName", roles.UserRoleName);
            parameters.Add("@PermissionGroupId", roles.PermissionGroupId);
            parameters.Add("@CreatedBy", roles.CreatedBy);
            parameters.Add("@IsActive", roles.IsActive);

            await _dbConnection.ExecuteScalarAsync<int>(UserRolesStoredProcedure.CreateUserRoles, parameters, commandType: CommandType.StoredProcedure);

            var userroleId = parameters.Get<int>("@UserRoleId");

            var createdRole = new UserRolesCreateResponseEntity
            {
                UserRoleId = userroleId,
                UserRoleName = roles.UserRoleName,
                PermissionGroupId = roles.PermissionGroupId,
                CreatedBy = roles.CreatedBy,
                IsActive = roles.IsActive,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            return createdRole;
        }

        public async Task<UserRolesUpdateResponseEntity?> UpdateUserRoles(UserRolesUpdateRequestEntity roles)
        {
            var paramters = new DynamicParameters();
            paramters.Add("@UserRoleId", roles.UserRoleId);
            paramters.Add("@UserRoleName", roles.UserRoleName);
            paramters.Add("@PermissionGroupId", roles.PermissionGroupId);
            paramters.Add("@UpdatedBy", roles.UpdatedBy);
            paramters.Add("@IsActive", roles.IsActive);
            paramters.Add("@IsDelete", roles.IsDelete);

            var result = await _dbConnection.ExecuteAsync(UserRolesStoredProcedure.UpdateUserRoles, paramters, commandType: CommandType.StoredProcedure);

            if (result == -1)
            {
                return null;
            }
            var updateUserRoles = new UserRolesUpdateResponseEntity
            {
                UserRoleId = roles.UserRoleId,
                UserRoleName = roles.UserRoleName,
                PermissionGroupId = roles.PermissionGroupId,
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
            parameters.Add("@UserRoleId", roles.UserRoleId);

            var result = await _dbConnection.ExecuteScalarAsync<int>(UserRolesStoredProcedure.DeleteUserRoles, parameters, commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
