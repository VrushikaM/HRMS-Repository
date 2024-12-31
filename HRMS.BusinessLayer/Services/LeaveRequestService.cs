using AutoMapper;
using HRMS.BusinessLayer.Interfaces;
using HRMS.Dtos.Leave.Leave.LeaveRequestDtos;
using HRMS.Dtos.Leave.Leave.LeaveResponseDtos;
using HRMS.Dtos.User.User.UserResponseDtos;
using HRMS.PersistenceLayer.Interfaces;
using HRMS.PersistenceLayer.Repositories;
using HRMS.Utility.Helpers.Passwords;

namespace HRMS.BusinessLayer.Services
{


    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestRepository _LeaveRequestRepository;
        private readonly IMapper _mapper;

        public LeaveRequestService(ILeaveRequestRepository LeaveRequestRepository, IMapper mapper)
        {
            _LeaveRequestRepository = LeaveRequestRepository;
            _mapper = mapper;
        }
        public Task<LeaveRequestCreateResponseDto> CreateUser(LeaveRequestCreateRequestDto leaveDto)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveRequestDeleteResponseDto?> DeleteUser(LeaveRequestDeleteRequestDto leaveDto)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveRequestReadResponseDto?> GetLeave(int? LeaveRequestid)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LeaveRequestReadResponseDto>> GetLeaves()
        {
            var leaves = await _LeaveRequestRepository.GetLeaves();
            var response= _mapper.Map<IEnumerable<LeaveRequestReadResponseDto>>(leaves);
            return response;
        }

        public async Task<LeaveRequestReadResponseDto?> GetUser(int? LeaveRequestid)
        {
            var leaves= await _LeaveRequestRepository.GetLeave(LeaveRequestid);
            if (leaves == null || leaves.LeaveRequestID == -1)
            {
                return null;
            }

           
            var response = _mapper.Map<LeaveRequestReadResponseDto>(leaves);
            return response;
        }

        public Task<LeaveRequestUpdateResponseDto> UpdateUser(LeaveRequestUpdateRequestDto leaveDto)
        {
            throw new NotImplementedException();
        }
    }
}
