using HRMS.Dtos.Leave.Leave.LeaveRequestDtos;
using HRMS.Dtos.Leave.Leave.LeaveResponseDtos;

namespace HRMS.BusinessLayer.Interfaces
{
    public interface ILeaveRequestService
    {
        Task<IEnumerable<LeaveRequestReadResponseDto>> GetLeaves();
        Task<LeaveRequestReadResponseDto?> GetLeave(int? LeaveRequestid);
        Task<LeaveRequestCreateResponseDto> CreateUser(LeaveRequestCreateRequestDto leaveDto);
        Task<LeaveRequestUpdateResponseDto> UpdateUser(LeaveRequestUpdateRequestDto leaveDto);
        Task<LeaveRequestDeleteResponseDto?> DeleteUser(LeaveRequestDeleteRequestDto leaveDto);
    }
}



