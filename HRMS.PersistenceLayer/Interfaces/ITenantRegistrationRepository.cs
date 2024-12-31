using HRMS.Entities.Tenant.TenantRegistration.TenantRegistrationRequestEntities;
using HRMS.Entities.Tenant.TenantRegistration.TenantRegistrationResponseEntities;

namespace HRMS.PersistenceLayer.Interfaces
{
    public interface ITenantRegistrationRepository
    {
        Task<TenantRegistrationCreateResponseEntity> CreateTenancyRole(TenantRegistrationCreateRequestEntity tenancyrole);
    }
}
