using Dapper;
using HRMS.Entities.Subdomain.Subdomain.SubdomainRequestEntites;
using HRMS.Entities.Subdomain.Subdomain.SubdomainResponseEntites;
using HRMS.Entities.Subdomain.Subdomain.SubdomainResponseEntities;
using HRMS.PersistenceLayer.Interfaces;
using HRMS.Utility.Helpers.SqlHelpers.Subdomain;
using HRMS.Utility.Helpers.SqlHelpers.User;
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
            var subdomains = await _dbConnection.QueryAsync<SubdomainReadResponseEntity>(SubdomainStoredProcedures.GetSubdomain, commandType: CommandType.StoredProcedure);
            return subdomains;
        }

        public async Task<SubdomainReadResponseEntity?> GetSubdomainById(int? subdomainId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@SubdomainId", subdomainId);
            var subdomain = await _dbConnection.QueryFirstOrDefaultAsync<SubdomainReadResponseEntity>(SubdomainStoredProcedures.GetSubdomain, parameters, commandType: CommandType.StoredProcedure);
            return subdomain;
        }

        public async Task<SubdomainCreateResponseEntity> CreateSubdomain(SubdomainCreateRequestEntity subdomain)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@SubdomainId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@DomainID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@SubdomainName", subdomain.SubdomainName);
            parameters.Add("@CreatedBy", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@IsActive", subdomain.IsActive);
            parameters.Add("@IsDelete", subdomain.IsDelete);

            await _dbConnection.ExecuteAsync(SubdomainStoredProcedures.CreateSubdomain, parameters, commandType: CommandType.StoredProcedure);

            var subdomainId = parameters.Get<int>("@SubdomainId");

            var CreatedSubdomain = new SubdomainCreateResponseEntity
            {
                SubdomainID = subdomainId,
                DomainID = subdomain.DomainID,
                SubdomainName = subdomain.SubdomainName,
                IsActive = subdomain.IsActive,
                IsDelete = subdomain.IsDelete
            };
            return CreatedSubdomain;
        }

        public Task<SubdomainUpdateResponseEntity?> UpdateSubdomain(SubdomainUpdateRequestEntity subdomain)
        {
            throw new NotImplementedException();
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
