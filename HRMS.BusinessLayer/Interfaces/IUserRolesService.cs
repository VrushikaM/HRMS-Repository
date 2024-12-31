using HRMS.Dtos.User.Roles.RolesRequestDtos;
using HRMS.Dtos.User.Roles.RolesResponseDtos;


namespace HRMS.BusinessLayer.Interfaces
{
    public interface IUserRolesService
    {
        Task<IEnumerable<UserRolesReadResponseDto>> GetAllUserRoles();

        Task<UserRolesReadResponseDto?> GetUserRolesById(int? rolesId);

        Task<UserRolesCreateResponseDto> CreateUserRole(UserRolesCreateRequestDto rolesDto);

        Task<UserRolesUpdateResponseDto> UpdateUserRoles(UserRolesUpdateRequestDto rolesDTo);

        Task<UserRolesDeleteResponseDto?> DeleteUserRoles(UserRolesDeleteRequestDto rolesDto);
    }
}
