using AutoMapper;
using HRMS.Dtos.User.Roles.RolesRequestDtos;
using HRMS.Dtos.User.Roles.RolesResponseDtos;
using HRMS.Entities.User.Roles.RolesRequestEntities;
using HRMS.Entities.User.Roles.RolesResponseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Utility.AutoMapperProfiles.User.RolesMapping
{
    public class RolesMappingProfile : Profile
    {
        public RolesMappingProfile()
        {
            CreateMap<RolesCreateRequestDto, RolesCreateRequestEntity>();
            CreateMap<RolesReadRequestDto, RolesReadRequestEntity>();
            CreateMap<RolesUpdateRequestDto, RolesUpdateRequestEntity>();
            CreateMap<RolesDeleteRequestDto, RolesDeleteRequestEntity>();


            CreateMap<RolesCreateRequestEntity, RolesCreateResponseEntity>();
            CreateMap<RolesReadRequestEntity, RolesReadResponseEntity>();
            CreateMap<RolesUpdateRequestEntity, RolesUpdateResponseEntity>();
            CreateMap<RolesDeleteRequestEntity,RolesDeleteResponseEntity>();


            CreateMap<RolesCreateResponseEntity, RolesCreateResponseDto>();
            CreateMap<RolesReadResponseEntity, RolesReadResponseDto>();
            CreateMap<RolesUpdateResponseEntity, RolesUpdateResponseDto>();
            CreateMap<RolesDeleteResponseEntity, RolesDeleteResponseDto>();
        }
    }
}
