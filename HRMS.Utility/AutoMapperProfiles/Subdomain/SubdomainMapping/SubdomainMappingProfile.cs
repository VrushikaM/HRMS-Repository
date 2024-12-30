using AutoMapper;
using HRMS.Dtos.Subdomain.Subdomain.SubdomainRequestDto;
using HRMS.Dtos.Subdomain.Subdomain.SubdomainResponseDto;
using HRMS.Entities.Subdomain.Subdomain.SubdomainRequestEntites;
using HRMS.Entities.Subdomain.Subdomain.SubdomainResponseEntites;
using HRMS.Entities.Subdomain.Subdomain.SubdomainResponseEntities;

namespace HRMS.Utility.AutoMapperProfiles.Subdomain.SubdomainMapping

{
    public class SubdomainMappingProfile: Profile
    {
        public SubdomainMappingProfile() { 
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
