using HRMS.Dtos.Tenant.TenantRegistration.TenantRegistrationRequestDtos;
using HRMS.Dtos.Tenant.TenantRegistration.TenantRegistrationResponseDtos;

namespace HRMS.BusinessLayer.Interfaces
{
    public interface ITenantRegistrationService
    {
        Task<TenantRegistrationCreateResponseDto> CreateTenantRegistration(TenantRegistrationCreateRequestDto tenantRegistrationDto);
    }
}
