using Dapper;
using HRMS.Entities.Tenant.Organization.OrganizationRequestEntities;
using HRMS.Entities.Tenant.Organization.OrganizationResponseEntities;
using HRMS.Entities.User.User.UserResponseEntities;
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
            parameters.Add("@OrganizationID", id);

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
            parameters.Add("@OrganizationID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@IsActive", organization.IsActive);

            var result = await _dbConnection.QuerySingleOrDefaultAsync<dynamic>(OrganizationStoreProcedures.CreateOrganization, parameters, commandType: CommandType.StoredProcedure);

            var organizationID = parameters.Get<int>("@OrganizationID");
            var createdOrganization = new OrganizationCreateResponseEntity
            {
                OrganizationID = organizationID,
                OrganizationName = organization.OrganizationName,
                CreatedBy = organization.CreatedBy,
                CreatedAt = DateTime.Now,
                UpdatedBy = result?.UpdatedBy,
                UpdatedAt = DateTime.Now,
                IsActive = organization.IsActive,
                IsDelete = result?.IsDelete
            };

            return createdOrganization;
        }

        public async Task<OrganizationUpdateResponseEntity?> UpdateOrganization(OrganizationUpdateRequestEntity organization)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OrganizationID", organization.OrganizationID);
            parameters.Add("@OrganizationName", organization.OrganizationName);
            parameters.Add("@UpdatedBy", organization.UpdatedBy);
            parameters.Add("@IsActive", organization.IsActive);
            parameters.Add("@IsDelete", organization.IsDelete);

            var result = await _dbConnection.QuerySingleOrDefaultAsync<OrganizationUpdateResponseEntity>(OrganizationStoreProcedures.UpdateOrganization, parameters, commandType: CommandType.StoredProcedure);

            if (result == null || result.OrganizationID == -1)
            {
                return null;
            }

            var UpdateOrganization = new OrganizationUpdateResponseEntity
            {
                OrganizationID = organization.OrganizationID,
                OrganizationName = organization.OrganizationName,
                CreatedBy = result.CreatedBy,
                CreatedAt = result.CreatedAt,
                UpdatedBy = organization.UpdatedBy,
                UpdatedAt = DateTime.Now,
                IsActive = organization.IsActive,
                IsDelete = organization.IsDelete
            };

            return UpdateOrganization;
        }

        public async Task<int> DeleteOrganization(OrganizationDeleteRequestEntity organization)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@OrganizationID", organization.OrganizationID);
            var response = await _dbConnection.ExecuteScalarAsync<int>(OrganizationStoreProcedures.DeleteOrganization, parameters, commandType: CommandType.StoredProcedure);
            return response;
        }
    }
}
