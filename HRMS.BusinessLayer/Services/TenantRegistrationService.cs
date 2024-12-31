using AutoMapper;
using HRMS.BusinessLayer.Interfaces;
using HRMS.Dtos.Tenant.TenantRegistration.TenantRegistrationRequestDtos;
using HRMS.Dtos.Tenant.TenantRegistration.TenantRegistrationResponseDtos;
using HRMS.Entities.Tenant.TenantRegistration.TenantRegistrationRequestEntities;
using HRMS.PersistenceLayer.Interfaces;

namespace HRMS.BusinessLayer.Services
{
    //private readonly ITenantRegistrationRepository _tenantRegistrationRepository;
    //private readonly IMapper _mapper;
    public class TenantRegistrationService : ITenantRegistrationService
    {
        //public async Task<TenantRegistrationCreateResponseDto> CreateTenantRegistration(TenantRegistrationCreateRequestDto tenantRegistrationDto)
        //{
        //    var tenantRegisterationEntity = _mapper.Map<TenantRegistrationCreateRequestEntity>(tenantRegistrationDto);
        //    var addedtenantRegisteration = await _tenantRegistrationRepository.CreateTenantRegistration(tenantRegisterEntity);
        //    var response = _mapper.Map<TenantRegistrationCreateResponseDto>(addedtenantRegisteration);
        //    return response;
        //}
    }
}
