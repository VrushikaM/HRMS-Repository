using HRMS.Dtos.Tenant.Subdomain.SubdomainRequestDto;
using HRMS.Dtos.Tenant.Subdomain.SubdomainResponseDto;

namespace HRMS.BusinessLayer.Interfaces
{
    public interface ISubdomainService
    {
        Task<IEnumerable<SubdomainReadResponseDto>> GetSubdomains();
        Task<SubdomainReadResponseDto?> GetSubdomainById(int? subdomainId);
        Task<SubdomainCreateResponseDto> CreateSubdomain(SubdomainCreateRequestDto subdomainDto);
        Task<SubdomainUpdateResponseDto> UpdateSubdomain(SubdomainUpdateRequestDto subdomainDto);
        Task<SubdomainDeleteResponseDto?> DeleteSubdomain(SubdomainDeleteRequestDto subdomainDto);
    }
}
