using Dapper;
using HRMS.Entities.Leave.Leave.LeaveRequestEntities;
using HRMS.Entities.Leave.Leave.LeaveResponseEntities;
using HRMS.PersistenceLayer.Interfaces;
using HRMS.Utility.Helpers.SqlHelpers.Leave;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.PersistenceLayer.Repositories
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly IDbConnection _dbConnection;

        public LeaveRequestRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public  Task<LeaveRequestCreateResponseEntity> CreateLeave(LeaveRequestCreateResponseEntity leave)
        {
            throw new NotImplementedException();

        }

        public Task<int> DeleteLeave(LeaveRequestDeleteRequestEntity leave)
        {
            throw new NotImplementedException();
        }

        public async Task<LeaveRequestReadResponseEntity?> GetLeave(int? LeaveRequestId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@LeaveRequestId", LeaveRequestId);
            var leaves = await _dbConnection.QueryFirstOrDefaultAsync<LeaveRequestReadResponseEntity>(LeaveRequestStoredProcedure.GetLeave, commandType: CommandType.StoredProcedure);
             return leaves;

        }

        public async Task<IEnumerable<LeaveRequestReadResponseEntity>> GetLeaves()
        {
            var leaves = await _dbConnection.QueryAsync<LeaveRequestReadResponseEntity>(LeaveRequestStoredProcedure.GetLeaves, commandType: CommandType.StoredProcedure);
            return leaves;

               
        }

        public Task<LeaveRequestUpdateResponseEntity> UpdateLeave(LeaveRequestUpdateResponseEntity leave)
        {
            throw new NotImplementedException();
        }
    }
}
