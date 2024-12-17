using BCrypt.Net;
using Dapper;
using HRMS.Entities.Models;
using HRMS.PersistenceLayer.Interfaces;
using System.Data;

namespace HRMS.PersistenceLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            var parameters = new DynamicParameters();

            var users = await _dbConnection.QueryAsync<Users>("spUserGetAll", parameters, commandType: CommandType.StoredProcedure);
            return users;
        }

        public async Task<IEnumerable<Users>> GetUser(int? userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);

            var user = await _dbConnection.QueryAsync<Users>("spUserGet", parameters, commandType: CommandType.StoredProcedure);
            return user;
        }

        public async Task<Users> CreateUser(Users user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@Email", user.Email);
            parameters.Add("@Password", user.Password);
            parameters.Add("@IsActive", user.IsActive);

            await _dbConnection.ExecuteAsync("spUserAdd", parameters, commandType: CommandType.StoredProcedure);

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = hashedPassword;
            user.UserId = parameters.Get<int>("@UserId");
            return user;
        }

        public async Task<Users> UpdateUser(Users user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", user.UserId);
            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@Email", user.Email);
            parameters.Add("@Password", user.Password);
            parameters.Add("@IsActive", user.IsActive);

            await _dbConnection.ExecuteAsync("spUserUpdate", parameters, commandType: CommandType.StoredProcedure);
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = hashedPassword;
            return user;
        }

        public async Task DeleteUser(Users user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", user.UserId);

            await _dbConnection.ExecuteAsync("spUserDelete", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
