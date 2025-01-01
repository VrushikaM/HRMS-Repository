using Dapper;
using HRMS.Entities.Tenant.Tenant.TenantRequestEntities;
using HRMS.Entities.Tenant.Tenant.TenantResponseEntities;
using HRMS.PersistenceLayer.Interfaces;
using HRMS.Utility.Helpers.SqlHelpers.Tenant;
using System.Data;

namespace HRMS.PersistenceLayer.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly IDbConnection _dbConnection;

        public TenantRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<TenantReadResponseEntity>> GetTenants()
        {
            var tenants = await _dbConnection.QueryAsync<TenantReadResponseEntity>(TenantStoredProcedures.GetTenants, commandType: CommandType.StoredProcedure);
            return tenants;
        }

        public async Task<TenantReadResponseEntity?> GetTenant(int? tenantId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TenantId", tenantId);

            var tenant = await _dbConnection.QueryFirstOrDefaultAsync<TenantReadResponseEntity>(TenantStoredProcedures.GetTenant, parameters, commandType: CommandType.StoredProcedure);
            return tenant;
        }

        public async Task<TenantCreateResponseEntity> CreateTenant(TenantCreateRequestEntity tenant)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TenantId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@OrganizationId", tenant.OrganizationId);
            parameters.Add("@TenantName", tenant.TenantName);
            parameters.Add("@DomainId", tenant.DomainId);
            parameters.Add("@SubdomainId", tenant.SubdomainId);
            parameters.Add("@IsActive", tenant.IsActive);
            parameters.Add("@IsDelete", tenant.IsDelete);
            parameters.Add("@CreatedBy", tenant.CreatedBy);

            await _dbConnection.ExecuteAsync(TenantStoredProcedures.CreateTenant, parameters, commandType: CommandType.StoredProcedure);

            var tenantId = parameters.Get<int>("@TenantId");
            //var hashedPassword = PasswordHashingUtility.HashPassword(user.Password);

            var createdTenant = new TenantCreateResponseEntity
            {
                TenantId = tenantId,
                OrganizationId = tenant.OrganizationId,
                TenantName = tenant.TenantName,
                CreatedBy = tenant.CreatedBy,
                DomainId = tenant.DomainId,
                SubdomainId = tenant.SubdomainId,
                IsActive = tenant.IsActive,
                IsDelete = tenant.IsDelete,

            };

            return createdTenant;
        }

        public async Task<TenantUpdateResponseEntity?> UpdateTenant(TenantUpdateRequestEntity tenant)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TenantId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@OrganizationId", tenant.OrganizationId);
            parameters.Add("@TenantName", tenant.TenantName);
            parameters.Add("@DomainId", tenant.DomainId);
            parameters.Add("@SubdomainId", tenant.SubdomainId);
            parameters.Add("@IsActive", tenant.IsActive);
            parameters.Add("@IsDelete", tenant.IsDelete);
            parameters.Add("@UpdatedBy", tenant.UpdatedBy);

            var result =
            await _dbConnection.ExecuteAsync(TenantStoredProcedures.UpdateTenant, parameters, commandType: CommandType.StoredProcedure);

            if (result == -1)
            {
                return null;
            }

            //var hashedPassword = PasswordHashingUtility.HashPassword(user.Password);

            var updateTenant = new TenantUpdateResponseEntity
            {
                TenantId = tenant.TenantId,
                OrganizationId = tenant.OrganizationId,
                TenantName = tenant.TenantName,
                SubdomainId = tenant.SubdomainId,
                IsActive = tenant.IsActive,
                IsDelete = tenant.IsDelete,

            };

            return updateTenant;
        }

        public async Task<int> DeleteTenant(TenantDeleteRequestEntity tenant)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TenantId", tenant.TenantId);

            var result = await _dbConnection.ExecuteAsync(TenantStoredProcedures.DeleteTenant, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
