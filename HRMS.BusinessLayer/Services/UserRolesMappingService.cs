using AutoMapper;
using HRMS.BusinessLayer.Interfaces;
using HRMS.Dtos.User.UserRoles.UserRolesResponseDtos;
using HRMS.Dtos.User.UserRolesMapping.UserRolesMappingRequestDtos;
using HRMS.Dtos.User.UserRolesMapping.UserRolesMappingResponseDtos;
using HRMS.Entities.User.UserRoles.UserRolesRequestEntities;
using HRMS.Entities.User.UserRolesMapping.UserRolesMappingRequestEntities;
using HRMS.PersistenceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessLayer.Services
{
    public class UserRolesMappingService : IUserRolesMappingService
    {
        private readonly IMapper _mapper;
        private readonly IUserRolesMappingRepository _userRolesMappingRepository;
        public UserRolesMappingService(IMapper mapper,IUserRolesMappingRepository userRolesMappingRepository) 
        {
          
            _mapper = mapper;
            _userRolesMappingRepository = userRolesMappingRepository;
        }

        public async Task<UserRolesMappingCreateResponseDto> CreateUserRoleMapping(UserRolesMappingCreateRequestDto rolesMappingDto)
        {
            var rolesMappingEntity = _mapper.Map<UserRolesMappingCreateRequestEntity>(rolesMappingDto);
            var addedUserMappingRole = await _userRolesMappingRepository.CreateUserRoleMapping(rolesMappingEntity);
            var response = _mapper.Map<UserRolesMappingCreateResponseDto>(addedUserMappingRole);
            return response;
        }

    }
}
