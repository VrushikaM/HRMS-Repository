using HRMS.Entities.Tenant.Tenant.TenantRequestEntities;
using HRMS.Entities.Tenant.Tenant.TenantResponseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.PersistenceLayer.Interfaces
{
    public interface ITenantRepository
    {
        Task<IEnumerable<TenantReadResponseEntity>> GetTenants();
        Task<TenantReadResponseEntity?> GetTenant(int? tenantId);
        Task<TenantCreateResponseEntity> CreateTenant(TenantCreateRequestEntity tenant);
        Task<TenantUpdateResponseEntity?> UpdateTenant(TenantUpdateRequestEntity tenant);
        Task<int> DeleteTenant(TenantDeleteRequestEntity tenant);
    }
}
