﻿using AutoMapper;
using HRMS.BusinessLayer.Interfaces;
using HRMS.Dtos.User.UserRequestModels;
using HRMS.Dtos.User.UserResponseModels;
using HRMS.Entities.User.UserRequestEntities;
using HRMS.Entities.User.UserRequestModels;
using HRMS.Entities.User.UserResponseEntities;
using HRMS.PersistenceLayer.Interfaces;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserReadResponseDto>> GetUsers()
    {
        var users = await _userRepository.GetUsers();
        foreach (var user in users)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        }
        var response = _mapper.Map<IEnumerable<UserReadResponseDto>>(users);
        return response;
    }

    public async Task<UserReadResponseDto?> GetUser(int? userId)
    {
        var user = await _userRepository.GetUser(userId);
        if (user == null || user.UserId == -1)
        {
            return null;
        }

        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

        var response = _mapper.Map<UserReadResponseDto>(user);
        return response;
    }

    public async Task<UserCreateResponseDto> CreateUser(UserCreateRequestDto userDto)
    {
        var userEntity = _mapper.Map<UserCreateRequestEntity>(userDto);
        var addedUser = await _userRepository.CreateUser(userEntity);
        var response = _mapper.Map<UserCreateResponseDto>(addedUser);
        return response;
    }

    public async Task<UserUpdateResponseDto> UpdateUser(UserUpdateRequestDto userDto)
    {
        var userEntity = _mapper.Map<UserUpdateRequestEntity>(userDto);
        var updatedUser = await _userRepository.UpdateUser(userEntity);
        var response = _mapper.Map<UserUpdateResponseDto>(updatedUser);
        return response;
    }

    public async Task<UserDeleteResponseDto?> DeleteUser(UserDeleteRequestDto userDto)
    {
        var userEntity = _mapper.Map<UserDeleteRequestEntity>(userDto);
        var result = await _userRepository.DeleteUser(userEntity);
        if (result == -1)
        {
            return null;
        }
        var responseEntity = new UserDeleteResponseEntity { UserId = userEntity.UserId };
        var responseDto = _mapper.Map<UserDeleteResponseDto>(responseEntity);

        return responseDto;
    }
}