using HRMS.Entities.Models;

namespace HRMS.PersistenceLayer.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users>> GetUsers();
        Task<IEnumerable<Users>> GetUser(int? userId);
        Task<Users> CreateUser(Users user);
        Task<Users> UpdateUser(Users user);
        Task DeleteUser(Users user);
    }
}
