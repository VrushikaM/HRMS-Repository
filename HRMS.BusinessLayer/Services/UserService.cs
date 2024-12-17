using AutoMapper;
using HRMS.BusinessLayer.Interfaces;
using HRMS.Dtos.User;
using HRMS.PersistenceLayer.Interfaces;
using HRMS.Entities.Models;

namespace HRMS.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserReadDto>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            foreach (var user in users)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            }
            var getUsers = _mapper.Map<IEnumerable<UserReadDto>>(users);
            return getUsers;
        }

        public async Task<IEnumerable<UserReadDto>> GetUser(int? userId)
        {
            var user = await _userRepository.GetUser(userId);
            foreach (var u in user)
            {
                u.Password = BCrypt.Net.BCrypt.HashPassword(u.Password);
            }
            var getUser = _mapper.Map<IEnumerable<UserReadDto>>(user);
            return getUser;
        }

        public async Task<Users> CreateUser(UserCreateDto userDto)
        {
            var addedUser = _mapper.Map<Users>(userDto);
            Users newUser = await _userRepository.CreateUser(addedUser);
            return newUser;
        }

        public async Task<Users> UpdateUser(UserUpdateDto userDto)
        {
            var updatedUser = _mapper.Map<Users>(userDto);
            Users updatedNewUser = await _userRepository.UpdateUser(updatedUser);
            return updatedNewUser;
        }

        public async Task DeleteUser(UserDeleteDto userDto)
        {
            var deletedUser = _mapper.Map<Users>(userDto);
            await _userRepository.DeleteUser(deletedUser);
        }
    }
}
