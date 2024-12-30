using AutoMapper;
using HRMS.Dtos.Tenant.Organization.OrganizationRequestDtos;
using HRMS.Dtos.Tenant.Organization.OrganizationResponseDtos;
using HRMS.Dtos.User.User.UserRequestDtos;
using HRMS.Entities.Tenant.Organization.OrganizationRequestEntities;
using HRMS.Entities.Tenant.Organization.OrganizationResponseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Utility.AutoMapperProfiles.Tenant.OrganizationMapping
{
    public class OrganizationMappingProfile : Profile
    {
        public OrganizationMappingProfile()
        {

            CreateMap<OrganizationCreateRequestDto, OrganizationCreateRequestEntity>();
            CreateMap<OrganizationReadRequestDto, OrganizationReadRequestEntity>();
            CreateMap<OrganizationUpdateRequestDto, OrganizationUpdateRequestEntity>();
            CreateMap<OrganizationDeleteRequestDto, OrganizationDeleteRequestEntity>();
     
            CreateMap<OrganizationCreateRequestEntity, OrganizationCreateResponseEntity>();
            CreateMap<OrganizationReadRequestEntity, OrganizationReadResponseEntity>();
            CreateMap<OrganizationUpdateRequestEntity, OrganizationUpdateResponseEntity>();
            CreateMap<OrganizationDeleteRequestEntity, OrganizationDeleteResponseEntity>();

            CreateMap<OrganizationCreateResponseEntity, OrganizationCreateResponseDto>();
            CreateMap<OrganizationReadResponseEntity, OrganizationReadResponseDto>();
            CreateMap<OrganizationUpdateResponseEntity, OrganizationUpdateResponseDto>();
            CreateMap<OrganizationDeleteResponseEntity, OrganizationDeleteResponseDto>();
        }
    }
}
