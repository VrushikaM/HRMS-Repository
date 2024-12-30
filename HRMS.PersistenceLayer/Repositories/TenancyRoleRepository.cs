using Dapper;
using HRMS.Entities.Tenant.TenancyRole.TenancyRoleRequestEntities;
using HRMS.Entities.Tenant.TenancyRole.TenancyRoleResponseEntities;
using HRMS.PersistenceLayer.Interfaces;
using HRMS.Utility.Helpers.SqlHelpers.Tenant;
using System.Data;

namespace HRMS.PersistenceLayer.Repositories
{
    public class TenancyRoleRepository : ITenancyRoleRepository
    {
        private readonly IDbConnection _dbConnection;

        public TenancyRoleRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<TenancyRoleReadResponseEntity>> GetTenancyRoles()
        {
            var roles = await _dbConnection.QueryAsync<TenancyRoleReadResponseEntity>(TenancyRoleStoredProcedure.GetTenancyRoles, commandType: CommandType.StoredProcedure);
            return roles;
        }

        public async Task<TenancyRoleReadResponseEntity?> GetTenancyRoleById(int? tenancyroleId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TenancyRoleID", tenancyroleId);

            var role = await _dbConnection.QueryFirstOrDefaultAsync<TenancyRoleReadResponseEntity>(TenancyRoleStoredProcedure.GetTenancyRoleById, parameters, commandType: CommandType.StoredProcedure);
            return role;
        }

        public async Task<TenancyRoleCreateResponseEntity> CreateTenancyRole(TenancyRoleCreateRequestEntity tenancyrole)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TenancyRoleID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@RoleName", tenancyrole.RoleName);
            parameters.Add("@CreatedBy", tenancyrole.CreatedBy);
            parameters.Add("@IsActive", tenancyrole.IsActive);

            await _dbConnection.ExecuteAsync(TenancyRoleStoredProcedure.CreateTenancyRole, parameters, commandType: CommandType.StoredProcedure);

            var roleId = parameters.Get<int>("@TenancyRoleID");

            var createdTenancyRole = new TenancyRoleCreateResponseEntity
            {
                TenancyRoleID = roleId,
                RoleName = tenancyrole.RoleName,
                CreatedBy = tenancyrole.CreatedBy,
                IsActive = tenancyrole.IsActive
            };

            return createdTenancyRole;
        }

        public async Task<TenancyRoleUpdateResponseEntity?> UpdateTenancyRole(TenancyRoleUpdateRequestEntity tenancyrole)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TenancyRoleID", tenancyrole.TenancyRoleID, dbType: DbType.Int32);
            parameters.Add("@RoleName", tenancyrole.RoleName);
            parameters.Add("@UpdatedBy", tenancyrole.UpdatedBy);
            parameters.Add("@IsActive", tenancyrole.IsActive);
            parameters.Add("@IsDelete", tenancyrole.IsDelete);

            var result = await _dbConnection.ExecuteAsync(TenancyRoleStoredProcedure.UpdateTenancyRole, parameters, commandType: CommandType.StoredProcedure);

            if (result == -1)
            {
                return null;
            }

            var updatedTenancyRole = new TenancyRoleUpdateResponseEntity
            {
                TenancyRoleID = tenancyrole.TenancyRoleID,
                RoleName = tenancyrole.RoleName,
                UpdatedBy = tenancyrole.UpdatedBy,
                IsActive = tenancyrole.IsActive,
                IsDelete = tenancyrole.IsDelete
            };

            return updatedTenancyRole;

        }
        public async Task<int> DeleteTenancyRole(TenancyRoleDeleteRequestEntity tenancyrole)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TenancyRoleID", tenancyrole.TenancyRoleID);

            var result = await _dbConnection.ExecuteScalarAsync<int>(TenancyRoleStoredProcedure.DeleteTenancyRole, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
