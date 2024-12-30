using AutoMapper;
using HRMS.BusinessLayer.Interfaces;
using HRMS.Dtos.Subdomain.Subdomain.SubdomainRequestDto;
using HRMS.Dtos.Subdomain.Subdomain.SubdomainResponseDto;
using HRMS.PersistenceLayer.Interfaces;

namespace HRMS.BusinessLayer.Services
{
    public class SubdomainService : ISubdomainService
    {
        private readonly ISubdomainRepository _subdomainRepository;
        private readonly IMapper _mapper;

        public SubdomainService(ISubdomainRepository subdomainRepository, IMapper mapper)
        {
            _subdomainRepository = subdomainRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SubdomainReadResponseDto>> GetSubdomains()
        {
            var subdomains = await _subdomainRepository.GetSubdomains();
            var response = _mapper.Map<IEnumerable<SubdomainReadResponseDto>>(subdomains);
            return response;
        }

        public async Task<SubdomainReadResponseDto?> GetSubdomainById(int? subdomainId)
        {
            var subdomain = await _subdomainRepository.GetSubdomainById(subdomainId);
            if (subdomain == null || subdomain.SubdomainID == -1)
            {
                return null;
            }
            var response = _mapper.Map<SubdomainReadResponseDto>(subdomain);
            return response;
        }
        public Task<SubdomainCreateResponseDto> CreateSubdomain(SubdomainCreateRequestDto subdomainDto)
        {
            throw new NotImplementedException();
        }
        public Task<SubdomainUpdateResponseDto> UpdateSubdomain(SubdomainUpdateRequestDto subdomainDto)
        {
            throw new NotImplementedException();
        }
        public Task<SubdomainDeleteResponseDto?> DeleteSubdomain(SubdomainDeleteRequestDto subdomainDto)
        {
            throw new NotImplementedException();
        }





    }
}
