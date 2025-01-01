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
            parameters.Add("@TenantID", tenantId);

            var tenant = await _dbConnection.QueryFirstOrDefaultAsync<TenantReadResponseEntity>(TenantStoredProcedures.GetTenant, parameters, commandType: CommandType.StoredProcedure);
            return tenant;
        }

        public async Task<TenantCreateResponseEntity> CreateTenant(TenantCreateRequestEntity tenant)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TenantID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@OrganizationID", tenant.OrganizationID);
            parameters.Add("@TenantName", tenant.TenantName);
            parameters.Add("@DomainID", tenant.DomainID);
            parameters.Add("@SubdomainID", tenant.SubdomainID);
            parameters.Add("@IsActive", tenant.IsActive);
            parameters.Add("@IsDelete", tenant.IsDelete);
            parameters.Add("@CreatedBy", tenant.CreatedBy);

            await _dbConnection.ExecuteAsync(TenantStoredProcedures.CreateTenant, parameters, commandType: CommandType.StoredProcedure);

            var tenantId = parameters.Get<int>("@TenantID");
            //var hashedPassword = PasswordHashingUtility.HashPassword(user.Password);

            var createdTenant = new TenantCreateResponseEntity
            {
                TenantID = tenantId,
                OrganizationID = tenant.OrganizationID,
                TenantName = tenant.TenantName,
                CreatedBy = tenant.CreatedBy,
                DomainID = tenant.DomainID,
                SubdomainID = tenant.DomainID,
                IsActive = tenant.IsActive,
                IsDelete = tenant.IsDelete,

            };

            return createdTenant;
        }

        public async Task<TenantUpdateResponseEntity?> UpdateTenant(TenantUpdateRequestEntity tenant)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TenantID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@OrganizationID", tenant.OrganizationID);
            parameters.Add("@TenantName", tenant.TenantName);
            parameters.Add("@DomainID", tenant.DomainID);
            parameters.Add("@SubdomainID", tenant.SubdomainID);
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
                TenantID = tenant.TenantID,
                OrganizationID = tenant.OrganizationID,
                TenantName = tenant.TenantName,
                DomainID = tenant.DomainID,
                SubdomainID = tenant.DomainID,
                IsActive = tenant.IsActive,
                IsDelete = tenant.IsDelete,

            };

            return updateTenant;
        }

        public async Task<int> DeleteTenant(TenantDeleteRequestEntity tenant)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TenantID", tenant.TenantID);

            var result = await _dbConnection.ExecuteAsync(TenantStoredProcedures.DeleteTenant, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
