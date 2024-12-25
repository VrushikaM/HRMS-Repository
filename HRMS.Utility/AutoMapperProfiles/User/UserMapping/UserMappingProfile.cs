using AutoMapper;
using HRMS.Dtos.User.User.UserRequestDtos;
using HRMS.Dtos.User.User.UserResponseDtos;
using HRMS.Entities.User.User.UserRequestEntities;
using HRMS.Entities.User.User.UserResponseEntities;

namespace HRMS.Utility.AutoMapperProfiles.User.UserMapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserCreateRequestDto, UserCreateRequestEntity>();
            CreateMap<UserReadRequestDto, UserReadRequestEntity>();
            CreateMap<UserUpdateRequestDto, UserUpdateRequestEntity>();
            CreateMap<UserDeleteRequestDto, UserDeleteRequestEntity>();

            CreateMap<UserCreateRequestEntity, UserCreateResponseEntity>();
            CreateMap<UserReadRequestEntity, UserReadResponseEntity>();
            CreateMap<UserUpdateRequestEntity, UserUpdateResponseEntity>();
            CreateMap<UserDeleteRequestEntity, UserDeleteResponseEntity>();

            CreateMap<UserCreateResponseEntity, UserCreateResponseDto>();
            CreateMap<UserReadResponseEntity, UserReadResponseDto>();
            CreateMap<UserUpdateResponseEntity, UserUpdateResponseDto>();
            CreateMap<UserDeleteResponseEntity, UserDeleteResponseDto>();
        }
    }
}
