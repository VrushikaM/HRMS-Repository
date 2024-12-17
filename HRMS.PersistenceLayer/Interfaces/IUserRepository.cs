using HRMS.Entities.User.UserRequestEntities;
using HRMS.Entities.User.UserRequestModels;
using HRMS.Entities.User.UserResponseEntities;

namespace HRMS.PersistenceLayer.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserReadResponseEntity>> GetUsers();
        Task<UserReadResponseEntity> GetUser(int? userId);
        Task<UserCreateResponseEntity> CreateUser(UserCreateRequestEntity user);
        Task<UserUpdateResponseEntity> UpdateUser(UserUpdateRequestEntity user);
        Task DeleteUser(UserDeleteRequestEntity user);
    }
}
