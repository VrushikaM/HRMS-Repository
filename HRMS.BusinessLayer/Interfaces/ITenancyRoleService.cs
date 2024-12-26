using HRMS.Dtos.Tenant3.TenancyRole.TenancyRoleRequestDtos;
using HRMS.Dtos.Tenant3.TenancyRole.TenancyRoleResponseDtos;

namespace HRMS.BusinessLayer.Interfaces
{
    public interface ITenancyRoleService
    {
        Task<IEnumerable<TenancyRoleReadResponseDto>> GetTenancyRoles();
        Task<TenancyRoleReadResponseDto?> GetTenancyRoleById(int? tenancyroleId);
        Task<TenancyRoleCreateResponseDto> CreateTenancyRole(TenancyRoleCreateRequestDto roleDto);
        Task<TenancyRoleUpdateResponseDto> UpdateTenancyRole(TenancyRoleUpdateRequestDto roleDto);
        Task<TenancyRoleDeleteResponseDto?> DeleteTenancyRole(TenancyRoleDeleteRequestDto roleDto);
    }
}
