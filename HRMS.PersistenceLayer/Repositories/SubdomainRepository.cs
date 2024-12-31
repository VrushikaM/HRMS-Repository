using Dapper;
using HRMS.Entities.Tenant.Subdomain.SubdomainRequestEntites;
using HRMS.Entities.Tenant.Subdomain.SubdomainResponseEntites;
using HRMS.PersistenceLayer.Interfaces;
using HRMS.Utility.Helpers.SqlHelpers.Tenant;
using System.Data;

namespace HRMS.PersistenceLayer.Repositories
{
    public class SubdomainRepository : ISubdomainRepository
    {
        private readonly IDbConnection _dbConnection;
        public SubdomainRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<SubdomainReadResponseEntity>> GetSubdomains()
        {
            var subdomains = await _dbConnection.QueryAsync<SubdomainReadResponseEntity>(SubdomainStoredProcedures.GetSubdomains, commandType: CommandType.StoredProcedure);
            return subdomains;
        }

        public async Task<SubdomainReadResponseEntity?> GetSubdomainById(int? subdomainId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@SubdomainID", subdomainId);
            var subdomain = await _dbConnection.QueryFirstOrDefaultAsync<SubdomainReadResponseEntity>(SubdomainStoredProcedures.GetSubdomainById, parameters, commandType: CommandType.StoredProcedure);
            return subdomain;
        }
        public async Task<SubdomainCreateResponseEntity> CreateSubdomain(SubdomainCreateRequestEntity subdomain)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@SubdomainID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@DomainID", subdomain.DomainID);
            parameters.Add("@SubdomainName", subdomain.SubdomainName);
            parameters.Add("@CreatedBy", subdomain.CreatedBy);
            parameters.Add("@IsActive", subdomain.IsActive);

            await _dbConnection.ExecuteAsync(SubdomainStoredProcedures.CreateSubdomain, parameters, commandType: CommandType.StoredProcedure);

            var subdomainId = parameters.Get<int>("@SubdomainID");

            var CreatedSubdomain = new SubdomainCreateResponseEntity
            {
                SubdomainID = subdomainId,
                DomainID = subdomain.DomainID,
                SubdomainName = subdomain.SubdomainName,
                IsActive = subdomain.IsActive,
                CreatedBy = subdomain.CreatedBy,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            return CreatedSubdomain;
        }
        public async Task<SubdomainUpdateResponseEntity?> UpdateSubdomain(SubdomainUpdateRequestEntity subdomain)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@SubdomainId", subdomain.SubdomainID);
            parameters.Add("@DomainID", subdomain.DomainID);
            parameters.Add("@SubdomainName", subdomain.SubdomainName);
            parameters.Add("@UpdatedBy", subdomain.UpdatedBy);
            parameters.Add("@IsActive", subdomain.IsActive);
            parameters.Add("@IsDelete", subdomain.IsDelete);

            await _dbConnection.ExecuteAsync(SubdomainStoredProcedures.UpdateSubdomain, parameters, commandType: CommandType.StoredProcedure);

            var updatedSubdomain = new SubdomainUpdateResponseEntity
            {
                SubdomainID = subdomain.SubdomainID,
                DomainID = subdomain.DomainID,
                SubdomainName = subdomain.SubdomainName,
                IsActive = subdomain.IsActive,
                IsDelete = subdomain.IsDelete,
                CreatedBy = subdomain.CreatedBy,
                UpdatedBy = subdomain.UpdatedBy,
                CreatedAt = subdomain.CreatedAt,
                UpdatedAt = DateTime.Now
            };
            return updatedSubdomain;
        }
        public async Task<int> DeleteSubdomain(SubdomainDeleteRequestEntity subdomain)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@SubdomainID", subdomain.SubdomainID);

            var result = await _dbConnection.ExecuteScalarAsync<int>(SubdomainStoredProcedures.DeleteSubdomain, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
