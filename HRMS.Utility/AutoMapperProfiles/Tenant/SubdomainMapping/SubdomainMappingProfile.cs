using AutoMapper;
using HRMS.Dtos.Tenant.Subdomain.SubdomainRequestDto;
using HRMS.Dtos.Tenant.Subdomain.SubdomainResponseDto;
using HRMS.Entities.Tenant.Subdomain.SubdomainRequestEntites;
using HRMS.Entities.Tenant.Subdomain.SubdomainResponseEntites;

namespace HRMS.Utility.AutoMapperProfiles.Tenant.SubdomainMapping

{
    public class SubdomainMappingProfile : Profile
    {
        public SubdomainMappingProfile()
        {
            CreateMap<SubdomainCreateRequestDto, SubdomainCreateRequestEntity>();
            CreateMap<SubdomainReadRequestDto, SubdomainReadRequestEntity>();
            CreateMap<SubdomainUpdateRequestDto, SubdomainUpdateRequestEntity>();
            CreateMap<SubdomainDeleteRequestDto, SubdomainDeleteRequestEntity>();

            CreateMap<SubdomainCreateRequestEntity, SubdomainCreateResponseEntity>();
            CreateMap<SubdomainReadRequestEntity, SubdomainReadResponseEntity>();
            CreateMap<SubdomainUpdateRequestEntity, SubdomainUpdateResponseEntity>();
            CreateMap<SubdomainDeleteRequestEntity, SubdomainDeleteResponseEntity>();

            CreateMap<SubdomainCreateResponseEntity, SubdomainCreateResponseDto>();
            CreateMap<SubdomainReadResponseEntity, SubdomainReadResponseDto>();
            CreateMap<SubdomainUpdateResponseEntity, SubdomainUpdateResponseDto>();
            CreateMap<SubdomainDeleteResponseEntity, SubdomainDeleteResponseDto>();
        }
    }
}
