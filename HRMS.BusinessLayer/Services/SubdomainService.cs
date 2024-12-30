using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
