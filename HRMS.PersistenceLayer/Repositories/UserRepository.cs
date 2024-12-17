using Dapper;
using HRMS.Entities.User.UserRequestEntities;
using HRMS.Entities.User.UserRequestModels;
using HRMS.Entities.User.UserResponseEntities;
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

        public async Task<IEnumerable<UserReadResponseEntity>> GetUsers()
        {
            var users = await _dbConnection.QueryAsync<UserReadResponseEntity>("spUserGetAll", commandType: CommandType.StoredProcedure);
            return users;
        }

        public async Task<UserReadResponseEntity> GetUser(int? userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);
            var user = await _dbConnection.QueryFirstOrDefaultAsync<UserReadResponseEntity>("spUserGet", parameters, commandType: CommandType.StoredProcedure);
            return user!;
        }

        public async Task<UserCreateResponseEntity> CreateUser(UserCreateRequestEntity user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@Email", user.Email);
            parameters.Add("@Password", user.Password);
            parameters.Add("@IsActive", user.IsActive);

            await _dbConnection.ExecuteAsync("spUserAdd", parameters, commandType: CommandType.StoredProcedure);


            var userId = parameters.Get<int>("@UserId");
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

            var createdUser = new UserCreateResponseEntity
            {
                UserId = userId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = hashedPassword,
                IsActive = user.IsActive
            };

            return createdUser;
        }

        public async Task<UserUpdateResponseEntity> UpdateUser(UserUpdateRequestEntity user)
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

            var updatedUser = new UserUpdateResponseEntity
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = hashedPassword,
                IsActive = user.IsActive
            };

            return updatedUser;
        }

        public async Task DeleteUser(UserDeleteRequestEntity user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", user.UserId);

            await _dbConnection.ExecuteAsync("spUserDelete", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}