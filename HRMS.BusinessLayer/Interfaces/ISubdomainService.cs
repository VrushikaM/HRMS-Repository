using HRMS.Dtos.Subdomain.Subdomain.SubdomainRequestDto;
using HRMS.Dtos.Subdomain.Subdomain.SubdomainResponseDto;

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
