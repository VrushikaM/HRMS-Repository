using HRMS.Entities.Tenant.TenancyRole.TenancyRoleRequestEntities;
using HRMS.Entities.Tenant.TenancyRole.TenancyRoleResponseEntities;

namespace HRMS.PersistenceLayer.Interfaces
{
    public interface ITenancyRoleRepository
    {
        Task<IEnumerable<TenancyRoleReadResponseEntity>> GetTenancyRoles();
        Task<TenancyRoleReadResponseEntity?> GetTenancyRoleById(int? tenancyroleId);
        Task<TenancyRoleCreateResponseEntity> CreateTenancyRole(TenancyRoleCreateRequestEntity tenancyrole);
        Task<TenancyRoleUpdateResponseEntity?> UpdateTenancyRole(TenancyRoleUpdateRequestEntity tenancyrole);
        Task<int> DeleteTenancyRole(TenancyRoleDeleteRequestEntity tenancyrole);
    }
}
