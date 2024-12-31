using HRMS.Entities.Tenant.TenantRegistration.TenantRegistrationRequestEntities;
using HRMS.Entities.Tenant.TenantRegistration.TenantRegistrationResponseEntities;
using HRMS.PersistenceLayer.Interfaces;

namespace HRMS.PersistenceLayer.Repositories
{
    public class TenantRegistrationRepository : ITenantRegistrationRepository
    {
        public Task<TenantRegistrationCreateResponseEntity> CreateTenancyRole(TenantRegistrationCreateRequestEntity tenancyrole)
        {
            throw new NotImplementedException();
        }
    }
}
