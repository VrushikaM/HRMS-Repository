using AutoMapper;
using HRMS.BusinessLayer.Interfaces;
using HRMS.Dtos.Tenant.Tenant.TenantRequestDtos;
using HRMS.Dtos.Tenant.Tenant.TenantResponseDtos;
using HRMS.Entities.Tenant.Tenant.TenantRequestEntities;
using HRMS.Entities.Tenant.Tenant.TenantResponseEntities;
using HRMS.PersistenceLayer.Interfaces;

namespace HRMS.BusinessLayer.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IMapper _mapper;

        public TenantService(ITenantRepository tenantRepository, IMapper mapper)
        {
            _tenantRepository = tenantRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TenantReadResponseDtos>> GetTenants()
        {
            var tenants = await _tenantRepository.GetTenants();
            //foreach (var tenant in tenants)
            //{
            //    user.Password = PasswordHashingUtility.HashPassword(user.Password);
            //}
            var response = _mapper.Map<IEnumerable<TenantReadResponseDtos>>(tenants);
            return response;
        }

        public async Task<TenantReadResponseDtos?> GetTenant(int? tenantId)
        {
            var tenant = await _tenantRepository.GetTenant(tenantId);
            if (tenant == null || tenant.TenantId == -1)
            {
                return null;
            }

            //user.Password = PasswordHashingUtility.HashPassword(user.Password);

            var response = _mapper.Map<TenantReadResponseDtos>(tenant);
            return response;
        }

        public async Task<TenantCreateResponseDtos> CreateTenant(TenantCreateRequestDtos tenantDto)
        {
            var tenantEntity = _mapper.Map<TenantCreateRequestEntity>(tenantDto);
            var addedTenant = await _tenantRepository.CreateTenant(tenantEntity);
            var response = _mapper.Map<TenantCreateResponseDtos>(addedTenant);
            return response;
        }

        public async Task<TenantUpdateResponseDtos> UpdateTenant(TenantUpdateRequestDtos tenantDto)
        {
            var tenantEntity = _mapper.Map<TenantUpdateRequestEntity>(tenantDto);
            var updatedTenant = await _tenantRepository.UpdateTenant(tenantEntity);
            var response = _mapper.Map<TenantUpdateResponseDtos>(updatedTenant);
            return response;
        }

        public async Task<TenantDeleteResponseDtos?> DeleteTenant(TenantDeleteRequestDtos tenantDto)
        {
            var tenantEntity = _mapper.Map<TenantDeleteRequestEntity>(tenantDto);
            var result = await _tenantRepository.DeleteTenant(tenantEntity);
            if (result == -1)
            {
                return null;
            }
            var responseEntity = new TenantDeleteResponseEntity { TenantId = tenantEntity.TenantId };
            var responseDto = _mapper.Map<TenantDeleteResponseDtos>(responseEntity);

            return responseDto;
        }
    }
}
