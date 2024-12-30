using AutoMapper.Configuration.Annotations;
using Dapper;
using HRMS.Entities.User.Roles.RolesRequestEntities;
using HRMS.Entities.User.Roles.RolesResponseEntities;
using HRMS.Entities.User.User.UserResponseEntities;
using HRMS.PersistenceLayer.Interfaces;
using HRMS.Utility.Helpers.SqlHelpers.User;
using System.Data;


namespace HRMS.PersistenceLayer.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly IDbConnection _dbConnection; 
        public RolesRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<RolesReadResponseEntity>> GetAllUserRoles()
        {
            var roles = await _dbConnection.QueryAsync<RolesReadResponseEntity>(RolesStoredProcedure.GetUserRoles, commandType: CommandType.StoredProcedure);
            return roles;
        }

        public async Task<RolesReadResponseEntity?> GetUserRolesById(int? rolesId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@RoleId", rolesId);

            var roles = await _dbConnection.QueryFirstOrDefaultAsync<RolesReadResponseEntity>(RolesStoredProcedure.GetUserRoles, parameters, commandType: CommandType.StoredProcedure);

            return roles;
        }


        public async Task<RolesCreateResponseEntity> CreateUserRole(RolesCreateRequestEntity roles)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@RoleId",dbType:DbType.Int32,direction:ParameterDirection.Output);
            parameters.Add("@RoleName", roles.RoleName);
            parameters.Add("@PermissionGroupId",roles.PermissionGroupId);
            parameters.Add("@CreatedBy",roles.CreatedBy);       
            parameters.Add("@IsActive", roles.IsActive);
           

            var role =   await _dbConnection.ExecuteScalarAsync<int>(RolesStoredProcedure.CreateUserRoles, parameters,commandType:CommandType.StoredProcedure);


            var roleId = parameters.Get<int>("@RoleId");

            var createdRole = new RolesCreateResponseEntity
            {
                RoleId = roleId,
                RoleName = roles.RoleName,
                PermissionGroupId = roles.PermissionGroupId,
                CreatedBy = roles.CreatedBy,            
                IsActive = roles.IsActive,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            return createdRole;
        }

        public async Task<RolesUpdateResponseEntity?> UpdateUserRoles(RolesUpdateRequestEntity roles)
        {
            var paramters = new DynamicParameters();
            paramters.Add("@RoleId", roles.RoleId);
            paramters.Add("@RoleName", roles.RoleName);
            paramters.Add("@PermissionGroupId", roles.PermissionGroupId);
            paramters.Add("@UpdatedBy", roles.UpdatedBy);
            paramters.Add("@IsActive", roles.IsActive);
            paramters.Add("@IsDelete", roles.IsDelete);

            var result = await _dbConnection.ExecuteAsync(RolesStoredProcedure.UpdateUserRoles, paramters, commandType: CommandType.StoredProcedure);

            if (result == -1)
            {
                return null;
            }
            var updateRoles = new RolesUpdateResponseEntity
            {
                RoleId = roles.RoleId,
                RoleName = roles.RoleName,
                PermissionGroupId = roles.PermissionGroupId,
                UpdatedBy = roles.UpdatedBy,
                UpdatedAt = DateTime.Now,
                IsActive = roles.IsActive,
                IsDelete = roles.IsDelete
            };
            return updateRoles;
        }

        public async Task<int> DeleteUserRoles(RolesDeleteRequestEntity roles)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@RoleId", roles.RoleId);

            var result = await _dbConnection.ExecuteScalarAsync<int>(RolesStoredProcedure.DeleteUserRoles, parameters, commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
