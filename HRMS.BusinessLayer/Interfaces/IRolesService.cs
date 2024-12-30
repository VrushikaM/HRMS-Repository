using HRMS.Dtos.User.Roles.RolesRequestDtos;
using HRMS.Dtos.User.Roles.RolesResponseDtos;
using HRMS.Dtos.User.User.UserRequestDtos;
using HRMS.Dtos.User.User.UserResponseDtos;


namespace HRMS.BusinessLayer.Interfaces
{
    public interface IRolesService
    {
        Task<IEnumerable<RolesReadResponseDto>> GetRoles();

        Task<RolesReadResponseDto?> GetRolesById(int? rolesId);

        Task<RolesCreateResponseDto> CreateRole(RolesCreateRequestDto rolesDto);

        Task<RolesUpdateResponseDto> UpdateRoles(RolesUpdateRequestDto rolesDTo);

        Task<RolesDeleteResponseDto?> DeleteRoles(RolesDeleteRequestDto rolesDto);
    }
}
