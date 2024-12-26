using AutoMapper;
using HRMS.Dtos.Tenant3.TenancyRole.TenancyRoleRequestDtos;
using HRMS.Dtos.Tenant3.TenancyRole.TenancyRoleResponseDtos;
using HRMS.Entities.Tenant3.TenancyRole.TenancyRoleRequestEntities;
using HRMS.Entities.Tenant3.TenancyRole.TenancyRoleResponseEntities;

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
