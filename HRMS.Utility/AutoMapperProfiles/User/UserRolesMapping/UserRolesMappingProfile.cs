using AutoMapper;
using HRMS.Dtos.User.UserRoles.UserRolesRequestDtos;
using HRMS.Dtos.User.UserRoles.UserRolesResponseDtos;
using HRMS.Entities.User.UserRoles.UserRolesRequestEntities;
using HRMS.Entities.User.UserRoles.UserRolesResponseEntities;

namespace HRMS.Utility.AutoMapperProfiles.User.UserRolesMapping
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
            CreateMap<UserRolesDeleteRequestEntity, UserRolesDeleteResponseEntity>();

            CreateMap<UserRolesCreateResponseEntity, UserRolesCreateResponseDto>();
            CreateMap<UserRolesReadResponseEntity, UserRolesReadResponseDto>();
            CreateMap<UserRolesUpdateResponseEntity, UserRolesUpdateResponseDto>();
            CreateMap<UserRolesDeleteResponseEntity, UserRolesDeleteResponseDto>();
        }
    }
}
