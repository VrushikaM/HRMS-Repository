using AutoMapper;
using HRMS.BusinessLayer.Interfaces;
using HRMS.Dtos.User.Roles.RolesRequestDtos;
using HRMS.Dtos.User.Roles.RolesResponseDtos;
using HRMS.Entities.User.Roles.RolesRequestEntities;
using HRMS.Entities.User.Roles.RolesResponseEntities;
using HRMS.PersistenceLayer.Interfaces;


namespace HRMS.BusinessLayer.Services
{
    public class UserRolesService:IUserRolesService
    {
        private readonly IUserRolesRepository _rolesRepository;
        private readonly IMapper _mapper;


        public UserRolesService(IUserRolesRepository rolesRepository,IMapper mapper) 
        { 
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<UserRolesReadResponseDto>> GetAllUserRoles()
        {
            var roles = await _rolesRepository.GetAllUserRoles();
            var response = _mapper.Map<IEnumerable<UserRolesReadResponseDto>>(roles);
            return response;
        }

        public async Task<UserRolesReadResponseDto?> GetUserRolesById(int? rolesId)
        {
            var role = await _rolesRepository.GetUserRolesById(rolesId);
            if (role == null || role.RoleId == -1)
            {
                return null;
            }
            var response = _mapper.Map<UserRolesReadResponseDto>(role);
            return response;
        }

        public async Task<UserRolesCreateResponseDto> CreateUserRole(UserRolesCreateRequestDto rolesDto)
        {
            var rolesEntity = _mapper.Map<UserRolesCreateRequestEntity>(rolesDto);
            var addedRole = await _rolesRepository.CreateUserRole(rolesEntity);
            var response = _mapper.Map<UserRolesCreateResponseDto>(addedRole);
            return response;
        }

        public async Task<UserRolesUpdateResponseDto> UpdateUserRoles(UserRolesUpdateRequestDto rolesDTo)
        {
            var rolesEntity = _mapper.Map<UserRolesUpdateRequestEntity>(rolesDTo);
            var updatedRoles = await _rolesRepository.UpdateUserRoles(rolesEntity);
            var response = _mapper.Map<UserRolesUpdateResponseDto>(updatedRoles);
            return response;
        }

        public async Task<UserRolesDeleteResponseDto?> DeleteUserRoles(UserRolesDeleteRequestDto rolesDto)
        {
            var rolesEntity = _mapper.Map<UserRolesDeleteRequestEntity>(rolesDto);
            var result = await _rolesRepository.DeleteUserRoles(rolesEntity);

            if(result == -1)
            {
                return null;
            }

            var responseEntity = new UserRolesDeleteResponseEntity { RoleId = rolesEntity.RoleId };
            var responseDto = _mapper.Map<UserRolesDeleteResponseDto>(responseEntity);

            return responseDto;
        }

    }
}
