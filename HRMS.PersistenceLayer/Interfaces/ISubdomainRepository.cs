using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.PersistenceLayer.Interfaces
{
    public interface ISubdomainRepository
    {
        Task<IEnumerable<SubdomainReadResponseEntity>> GetSubdomains();
        Task<SubdomainReadResponseEntity?> GetSubdomain(int? subdomainId);
        Task<SubdomainCreateResponseEntity> CreateSubdomain(SubdomainCreateRequestEntity subdomain);

    }
}
