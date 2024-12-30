using HRMS.Entities.Subdomain.Subdomain.SubdomainRequestEntites;
using HRMS.Entities.Subdomain.Subdomain.SubdomainResponseEntites;
using HRMS.Entities.Subdomain.Subdomain.SubdomainResponseEntities;

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
