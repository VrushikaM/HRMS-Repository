using AutoMapper;
using HRMS.BusinessLayer.Interfaces;
using HRMS.Dtos.User.Roles.RolesRequestDtos;
using HRMS.Dtos.User.Roles.RolesResponseDtos;
using HRMS.Entities.User.Roles.RolesRequestEntities;
using HRMS.Entities.User.Roles.RolesResponseEntities;
using HRMS.PersistenceLayer.Interfaces;


namespace HRMS.BusinessLayer.Services
{
    public class RolesService:IRolesService
    {
        private readonly IRolesRepository _rolesRepository;
        private readonly IMapper _mapper;


        public RolesService(IRolesRepository rolesRepository,IMapper mapper) 
        { 
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<RolesReadResponseDto>> GetAllUserRoles()
        {
            var roles = await _rolesRepository.GetAllUserRoles();
            var response = _mapper.Map<IEnumerable<RolesReadResponseDto>>(roles);
            return response;
        }

        public async Task<RolesReadResponseDto?> GetUserRolesById(int? rolesId)
        {
            var role = await _rolesRepository.GetUserRolesById(rolesId);
            if (role == null || role.RoleId == -1)
            {
                return null;
            }
            var response = _mapper.Map<RolesReadResponseDto>(role);
            return response;
        }

        public async Task<RolesCreateResponseDto> CreateUserRole(RolesCreateRequestDto rolesDto)
        {
            var rolesEntity = _mapper.Map<RolesCreateRequestEntity>(rolesDto);
            var addedRole = await _rolesRepository.CreateUserRole(rolesEntity);
            var response = _mapper.Map<RolesCreateResponseDto>(addedRole);
            return response;
        }

        public async Task<RolesUpdateResponseDto> UpdateUserRoles(RolesUpdateRequestDto rolesDTo)
        {
            var rolesEntity = _mapper.Map<RolesUpdateRequestEntity>(rolesDTo);
            var updatedRoles = await _rolesRepository.UpdateUserRoles(rolesEntity);
            var response = _mapper.Map<RolesUpdateResponseDto>(updatedRoles);
            return response;
        }

        public async Task<RolesDeleteResponseDto?> DeleteUserRoles(RolesDeleteRequestDto rolesDto)
        {
            var rolesEntity = _mapper.Map<RolesDeleteRequestEntity>(rolesDto);
            var result = await _rolesRepository.DeleteUserRoles(rolesEntity);

            if(result == -1)
            {
                return null;
            }

            var responseEntity = new RolesDeleteResponseEntity { RoleId = rolesEntity.RoleId };
            var responseDto = _mapper.Map<RolesDeleteResponseDto>(responseEntity);

            return responseDto;
        }

    }
}
