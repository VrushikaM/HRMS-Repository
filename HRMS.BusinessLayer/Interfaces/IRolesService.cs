using HRMS.Dtos.User.Roles.RolesRequestDtos;
using HRMS.Dtos.User.Roles.RolesResponseDtos;
using HRMS.Dtos.User.User.UserRequestDtos;
using HRMS.Dtos.User.User.UserResponseDtos;


namespace HRMS.BusinessLayer.Interfaces
{
    public interface IRolesService
    {
        Task<IEnumerable<RolesReadResponseDto>> GetAllUserRoles();

        Task<RolesReadResponseDto?> GetUserRolesById(int? rolesId);

        Task<RolesCreateResponseDto> CreateUserRole(RolesCreateRequestDto rolesDto);

        Task<RolesUpdateResponseDto> UpdateUserRoles(RolesUpdateRequestDto rolesDTo);

        Task<RolesDeleteResponseDto?> DeleteUserRoles(RolesDeleteRequestDto rolesDto);
    }
}
