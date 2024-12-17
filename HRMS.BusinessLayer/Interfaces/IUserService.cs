using HRMS.Dtos.User;
using HRMS.Entities.Models;

namespace HRMS.BusinessLayer.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadDto>> GetUsers();
        Task<IEnumerable<UserReadDto>> GetUser(int? userId);
        Task<Users> CreateUser(UserCreateDto userDto);
        Task<Users> UpdateUser(UserUpdateDto userDto);
        Task DeleteUser(UserDeleteDto userDto);
    }
}
