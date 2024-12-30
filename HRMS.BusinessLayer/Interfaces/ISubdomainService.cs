using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessLayer.Interfaces
{
    Public interface ISubdomainService
    {
        Task<IEnumerable<SubdomainReadResponseDto>> GetSubdomains();
        Task<SubdomainReadResponseDto?> GetSubdomain(int? subdomainId);
        Task<SubdomainCreateResponseDto> CreateSubdomain(SubdomainCreateRequestDto subdomainDto);
        Task<SubdomainUpdateResponseDto> UpdateSubdomain(SubdomainUpdateRequestDto subdomainDto);
        Task<SubdomainDeleteResponseDto?> DeleteSubdomain(SubdomainDeleteRequestDto subdomainDto);
    }
}
