using AutoMapper;
using HRMS.Dtos.User;
using HRMS.Entities.Models;

namespace HRMS.BusinessLayer.User
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserCreateDto, Users>();
            CreateMap<UserUpdateDto, Users>();
            CreateMap<Users, UserReadDto>();
            CreateMap<UserDeleteDto, Users>();
        }
    }
}
