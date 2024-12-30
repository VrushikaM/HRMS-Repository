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


        public async Task<IEnumerable<RolesReadResponseDto>> GetRoles()
        {
            var roles = await _rolesRepository.GetRoles();
            var response = _mapper.Map<IEnumerable<RolesReadResponseDto>>(roles);
            return response;
        }

        public async Task<RolesReadResponseDto?> GetRolesById(int? rolesId)
        {
            var role = await _rolesRepository.GetRolesById(rolesId);
            if (role == null || role.RoleId == -1)
            {
                return null;
            }
            var response = _mapper.Map<RolesReadResponseDto>(role);
            return response;
        }

        public async Task<RolesCreateResponseDto> CreateRole(RolesCreateRequestDto rolesDto)
        {
            var rolesEntity = _mapper.Map<RolesCreateRequestEntity>(rolesDto);
            var addedRole = await _rolesRepository.CreateRole(rolesEntity);
            var response = _mapper.Map<RolesCreateResponseDto>(addedRole);
            return response;
        }

        public async Task<RolesUpdateResponseDto> UpdateRoles(RolesUpdateRequestDto rolesDTo)
        {
            var rolesEntity = _mapper.Map<RolesUpdateRequestEntity>(rolesDTo);
            var updatedRoles = await _rolesRepository.UpdateRoles(rolesEntity);
            var response = _mapper.Map<RolesUpdateResponseDto>(updatedRoles);
            return response;
        }

        public async Task<RolesDeleteResponseDto?>DeleteRoles(RolesDeleteRequestDto rolesDto)
        {
            var rolesEntity = _mapper.Map<RolesDeleteRequestEntity>(rolesDto);
            var result = await _rolesRepository.DeleteRoles(rolesEntity);

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
