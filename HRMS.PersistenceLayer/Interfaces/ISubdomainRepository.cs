using HRMS.Entities.Tenant.Subdomain.SubdomainRequestEntites;
using HRMS.Entities.Tenant.Subdomain.SubdomainResponseEntites;

namespace HRMS.PersistenceLayer.Interfaces
{
    public interface ISubdomainRepository
    {
        Task<IEnumerable<SubdomainReadResponseEntity>> GetSubdomains();
        Task<SubdomainReadResponseEntity?> GetSubdomainById(int? subdomainId);
        Task<SubdomainCreateResponseEntity> CreateSubdomain(SubdomainCreateRequestEntity subdomain);
        Task<SubdomainUpdateResponseEntity?> UpdateSubdomain(SubdomainUpdateRequestEntity subdomain);
        Task<int> DeleteSubdomain(SubdomainDeleteRequestEntity subdomain);
    }
}
