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
    public class UserRolesMappingProfile : Profile
    {
        public UserRolesMappingProfile()
        {
            CreateMap<UserRolesCreateRequestDto, UserRolesCreateRequestEntity>();
            CreateMap<UserRolesReadRequestDto, UserRolesReadRequestEntity>();
            CreateMap<UserRolesUpdateRequestDto, UserRolesUpdateRequestEntity>();
            CreateMap<UserRolesDeleteRequestDto, UserRolesDeleteRequestEntity>();


            CreateMap<UserRolesCreateRequestEntity, UserRolesCreateResponseEntity>();
            CreateMap<UserRolesReadRequestEntity, UserRolesReadResponseEntity>();
            CreateMap<UserRolesUpdateRequestEntity, UserRolesUpdateResponseEntity>();
            CreateMap<UserRolesDeleteRequestEntity,UserRolesDeleteResponseEntity>();


            CreateMap<UserRolesCreateResponseEntity, UserRolesCreateResponseDto>();
            CreateMap<UserRolesReadResponseEntity, UserRolesReadResponseDto>();
            CreateMap<UserRolesUpdateResponseEntity, UserRolesUpdateResponseDto>();
            CreateMap<UserRolesDeleteResponseEntity, UserRolesDeleteResponseDto>();
        }
    }
}
