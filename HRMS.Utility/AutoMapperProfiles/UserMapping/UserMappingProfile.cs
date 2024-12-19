using AutoMapper;
using HRMS.Dtos.User.UserRequestModels;
using HRMS.Dtos.User.UserResponseModels;
using HRMS.Entities.User.UserRequestEntities;
using HRMS.Entities.User.UserRequestModels;
using HRMS.Entities.User.UserResponseEntities;

namespace HRMS.Utility.AutoMapperProfiles.UserMapping
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
