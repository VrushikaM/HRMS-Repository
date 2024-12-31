using HRMS.Entities.Leave.Leave.LeaveRequestEntities;
using HRMS.Entities.Leave.Leave.LeaveResponseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.PersistenceLayer.Interfaces
{
    public interface ILeaveRequestRepository
    {
        Task<IEnumerable<LeaveRequestReadResponseEntity>> GetLeaves();
        Task<LeaveRequestReadResponseEntity?> GetLeave(int?LeaveRequestId);
        Task<LeaveRequestCreateResponseEntity> CreateLeave(LeaveRequestCreateResponseEntity leave);
        Task<LeaveRequestUpdateResponseEntity> UpdateLeave(LeaveRequestUpdateResponseEntity leave);
        Task<int> DeleteLeave(LeaveRequestDeleteRequestEntity leave);

    }
}
