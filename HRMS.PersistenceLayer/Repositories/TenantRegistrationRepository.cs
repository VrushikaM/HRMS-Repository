using Dapper;
using HRMS.Entities.Tenant.TenantRegistration.TenantRegistrationRequestEntities;
using HRMS.Entities.Tenant.TenantRegistration.TenantRegistrationResponseEntities;
using HRMS.PersistenceLayer.Interfaces;
using HRMS.Utility.Helpers.Passwords;
using HRMS.Utility.Helpers.SqlHelpers.Tenant;
using System.Data;

namespace HRMS.PersistenceLayer.Repositories
{
    public class TenantRegistrationRepository : ITenantRegistrationRepository
    {
        private readonly IDbConnection _dbConnection;

        public TenantRegistrationRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<TenantRegistrationCreateResponseEntity> CreateTenantRegistration(TenantRegistrationCreateRequestEntity tenantregistration)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@SubdomainName", tenantregistration.SubdomainName);
            parameters.Add("@FirstName", tenantregistration.FirstName);
            parameters.Add("@LastName", tenantregistration.LastName);
            parameters.Add("@UserName", tenantregistration.UserName);
            parameters.Add("@Email", tenantregistration.Email);
            parameters.Add("@Password", tenantregistration.Password);

            await _dbConnection.ExecuteAsync(TenantRegistrationStoreProcedures.CreateTenantRegistration, parameters, commandType: CommandType.StoredProcedure);

            //var roleId = parameters.Get<int>("@TenancyRoleID");
            var hashedPassword = PasswordHashingUtility.HashPassword(tenantregistration.Password);
            var createdTenantregistration = new TenantRegistrationCreateResponseEntity
            {
                //SubdomainName = roleId,
                SubdomainName = tenantregistration.SubdomainName,
                FirstName = tenantregistration.FirstName,
                LastName = tenantregistration.LastName,
                UserName = tenantregistration.UserName,
                Email = tenantregistration.Email,
                Password = hashedPassword
            };

            return createdTenantregistration;
        }
    }
}
