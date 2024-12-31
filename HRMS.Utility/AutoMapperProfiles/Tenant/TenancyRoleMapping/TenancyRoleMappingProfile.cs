using AutoMapper;
using HRMS.Dtos.Tenant.TenancyRole.TenancyRoleRequestDtos;
using HRMS.Dtos.Tenant.TenancyRole.TenancyRoleResponseDtos;
using HRMS.Entities.Tenant.TenancyRole.TenancyRoleRequestEntities;
using HRMS.Entities.Tenant.TenancyRole.TenancyRoleResponseEntities;

namespace HRMS.Utility.AutoMapperProfiles.Tenant.TenancyRoleMapping
{
    public class TenancyRoleMappingProfile : Profile
    {
        public TenancyRoleMappingProfile()
        {
            CreateMap<TenancyRoleCreateRequestDto, TenancyRoleCreateRequestEntity>();
            CreateMap<TenancyRoleReadRequestDto, TenancyRoleReadRequestEntity>();
            CreateMap<TenancyRoleUpdateRequestDto, TenancyRoleUpdateRequestEntity>();
            CreateMap<TenancyRoleDeleteRequestDto, TenancyRoleDeleteRequestEntity>();

            CreateMap<TenancyRoleCreateRequestEntity, TenancyRoleCreateResponseEntity>();
            CreateMap<TenancyRoleReadRequestEntity, TenancyRoleReadResponseEntity>();
            CreateMap<TenancyRoleUpdateRequestEntity, TenancyRoleUpdateResponseEntity>();
            CreateMap<TenancyRoleDeleteRequestEntity, TenancyRoleDeleteResponseEntity>();

            CreateMap<TenancyRoleCreateResponseEntity, TenancyRoleCreateResponseDto>();
            CreateMap<TenancyRoleReadResponseEntity, TenancyRoleReadResponseDto>();
            CreateMap<TenancyRoleUpdateResponseEntity, TenancyRoleUpdateResponseDto>();
            CreateMap<TenancyRoleDeleteResponseEntity, TenancyRoleDeleteResponseDto>();
        }
    }
}
