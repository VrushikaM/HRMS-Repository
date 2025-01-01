using Dapper;
using HRMS.Entities.User.User.UserRequestEntities;
using HRMS.Entities.User.User.UserResponseEntities;
using HRMS.PersistenceLayer.Interfaces;
using HRMS.Utility.Helpers.Passwords;
using HRMS.Utility.Helpers.SqlHelpers.User;
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
            var users = await _dbConnection.QueryAsync<UserReadResponseEntity>(UserStoredProcedures.GetUsers, commandType: CommandType.StoredProcedure);

            foreach (var user in users)
            {
                user.DateOfBirth = DateOnly.FromDateTime(user.DateOfBirth).ToDateTime(TimeOnly.MinValue);
            }

            return users;
        }

        public async Task<UserReadResponseEntity?> GetUserById(int? userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);

            var user = await _dbConnection.QueryFirstOrDefaultAsync<UserReadResponseEntity>(UserStoredProcedures.GetUserById, parameters, commandType: CommandType.StoredProcedure);
            return user;
        }

        public async Task<UserCreateResponseEntity> CreateUser(UserCreateRequestEntity user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@MiddleName", user.MiddleName);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@UserName", user.UserName);
            parameters.Add("@Email", user.Email);
            parameters.Add("@Password", user.Password);
            parameters.Add("@Gender", user.Gender);
            parameters.Add("@DateOfBirth", user.DateOfBirth.ToDateTime(new TimeOnly(0, 0)));
            parameters.Add("@IsActive", user.IsActive);
            parameters.Add("@IsDelete", user.IsDelete);
            parameters.Add("@CreatedBy", user.CreatedBy);
            parameters.Add("@TenantId", user.TenantId);
            parameters.Add("@RoleId", user.RoleId);
            parameters.Add("@TenancyRoleId", user.TenancyRoleId);

            await _dbConnection.ExecuteAsync(UserStoredProcedures.CreateUSer, parameters, commandType: CommandType.StoredProcedure);

            var userId = parameters.Get<int>("@UserId");
            var hashedPassword = PasswordHashingUtility.HashPassword(user.Password);

            var createdUser = new UserCreateResponseEntity
            {
                UserId = userId,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Password = hashedPassword,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth,
                IsActive = user.IsActive,
                IsDelete = user.IsDelete,
                TenantId = user.TenantId,
                RoleId = user.RoleId,
                TenancyRoleId = user.TenancyRoleId,
                CreatedBy = user.CreatedBy,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            return createdUser;
        }

        public async Task<UserUpdateResponseEntity?> UpdateUser(UserUpdateRequestEntity user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", user.UserId);
            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@MiddleName", user.MiddleName);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@UserName", user.UserName);
            parameters.Add("@Email", user.Email);
            parameters.Add("@Password", user.Password);
            parameters.Add("@Gender", user.Gender);
            parameters.Add("@DateOfBirth", user.DateOfBirth.ToDateTime(new TimeOnly(0, 0)));
            parameters.Add("@IsActive", user.IsActive);
            parameters.Add("@IsDelete", user.IsDelete);
            parameters.Add("@UpdatedBy", user.UpdatedBy);
            parameters.Add("@TenantId", user.TenantId);
            parameters.Add("@RoleId", user.RoleId);
            parameters.Add("@TenancyRoleId", user.TenancyRoleId);

            var result = await _dbConnection.ExecuteAsync(UserStoredProcedures.UpdateUser, parameters, commandType: CommandType.StoredProcedure);

            if (result == -1)
            {
                return null;
            }

            var hashedPassword = PasswordHashingUtility.HashPassword(user.Password);

            var updatedUser = new UserUpdateResponseEntity
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Password = hashedPassword,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth,
                IsActive = user.IsActive,
                IsDelete = user.IsDelete,
                TenantId = user.TenantId,
                RoleId = user.RoleId,
                TenancyRoleId = user.TenancyRoleId,
                UpdatedAt = DateTime.Now,
                UpdatedBy = user.UpdatedBy,
            };

            return updatedUser;
        }

        public async Task<int> DeleteUser(UserDeleteRequestEntity user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", user.UserId);

            var result = await _dbConnection.ExecuteScalarAsync<int>(UserStoredProcedures.DeleteUSer, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}