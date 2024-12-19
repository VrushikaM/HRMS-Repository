using HRMS.Dtos.User.UserRequestModels;
using HRMS.Dtos.User.UserResponseModels;

namespace HRMS.BusinessLayer.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadResponseDto>> GetUsers();
        Task<UserReadResponseDto?> GetUser(int? userId);
        Task<UserCreateResponseDto> CreateUser(UserCreateRequestDto userDto);
        Task<UserUpdateResponseDto> UpdateUser(UserUpdateRequestDto userDto);
        Task<UserDeleteResponseDto?> DeleteUser(UserDeleteRequestDto userDto);
    }
}
