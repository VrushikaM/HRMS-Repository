using Dapper;
using HRMS.Entities.Tenant.Organization.OrganizationRequestEntities;
using HRMS.Entities.Tenant.Organization.OrganizationResponseEntities;
using HRMS.PersistenceLayer.Interfaces;
using HRMS.Utility.Helpers.SqlHelpers.Tenant;
using System.Data;

namespace HRMS.PersistenceLayer.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly IDbConnection _dbConnection;

        public OrganizationRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<OrganizationReadResponseEntity>> GetOrganizations()
        {

            var organizations = await _dbConnection.QueryAsync<OrganizationReadResponseEntity>(
                OrganizationStoreProcedures.GetOrganizations,
                commandType: CommandType.StoredProcedure
            );
            return organizations;
        }

        public async Task<OrganizationReadResponseEntity?> GetOrganizationById(int? id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OrganizationId", id);

            var organization = await _dbConnection.QueryFirstOrDefaultAsync<OrganizationReadResponseEntity>(
                OrganizationStoreProcedures.GetOrganizationById,
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return organization;
        }

        public async Task<OrganizationCreateResponseEntity> CreateOrganization(OrganizationCreateRequestEntity organization)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OrganizationName", organization.OrganizationName);
            parameters.Add("@CreatedBy", organization.CreatedBy);
            parameters.Add("@OrganizationId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@IsActive", organization.IsActive);

            await _dbConnection.ExecuteAsync(OrganizationStoreProcedures.CreateOrganization, parameters, commandType: CommandType.StoredProcedure);

            var organizationId = parameters.Get<int>("@OrganizationId");
            var createdOrganization = new OrganizationCreateResponseEntity
            {
                OrganizationId = organizationId,
                OrganizationName = organization.OrganizationName,
                CreatedBy = organization.CreatedBy,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = organization.IsActive
            };

            return createdOrganization;
        }

        public async Task<OrganizationUpdateResponseEntity> UpdateOrganization(OrganizationUpdateRequestEntity organization)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OrganizationId", organization.OrganizationId);
            parameters.Add("@OrganizationName", organization.OrganizationName);
            parameters.Add("@UpdatedBy", organization.UpdatedBy);
            parameters.Add("@IsActive", organization.IsActive);

            await _dbConnection.ExecuteAsync(OrganizationStoreProcedures.UpdateOrganization, parameters, commandType: CommandType.StoredProcedure);

            var UpdateOrganization = new OrganizationUpdateResponseEntity
            {
                OrganizationId = organization.OrganizationId,
                OrganizationName = organization.OrganizationName,
                UpdatedBy = organization.UpdatedBy,
                IsActive = organization.IsActive,
                UpdatedaAt = DateTime.Now,
            };
            return UpdateOrganization;
        }

        public async Task<int> DeleteOrganization(OrganizationDeleteRequestEntity organization)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OrganizationId", organization.OrganizationId);
            var response = await _dbConnection.ExecuteScalarAsync<int>(OrganizationStoreProcedures.DeleteOrganization, parameters, commandType: CommandType.StoredProcedure);
            return response;
        }
    }
}
