using AutoMapper;
using HRMS.Dtos.Tenant.Tenant.TenantRequestDtos;
using HRMS.Dtos.Tenant.Tenant.TenantResponseDtos;
using HRMS.Entities.Tenant.Tenant.TenantRequestEntities;
using HRMS.Entities.Tenant.Tenant.TenantResponseEntities;

namespace HRMS.Utility.AutoMapperProfiles.Tenant.TenantMapping
{
    public class TenantMappingProfile : Profile
    {
        public TenantMappingProfile()
        {
            CreateMap<TenantCreateRequestDtos, TenantCreateRequestEntity>();
            CreateMap<TenantReadRequestDtos, TenantReadRequestEntity>();
            CreateMap<TenantUpdateRequestDtos, TenantUpdateRequestEntity>();
            CreateMap<TenantDeleteRequestDtos, TenantDeleteRequestEntity>();

            CreateMap<TenantCreateRequestEntity, TenantCreateResponseEntity>();
            CreateMap<TenantReadRequestEntity, TenantReadResponseEntity>();
            CreateMap<TenantUpdateRequestEntity, TenantUpdateResponseEntity>();
            CreateMap<TenantDeleteRequestEntity, TenantDeleteResponseEntity>();

            CreateMap<TenantCreateResponseEntity, TenantCreateResponseDtos>();
            CreateMap<TenantReadResponseEntity, TenantReadResponseDtos>();
            CreateMap<TenantUpdateResponseEntity, TenantUpdateResponseDtos>();
            CreateMap<TenantDeleteResponseEntity, TenantDeleteResponseDtos>();
        }
    }
}
