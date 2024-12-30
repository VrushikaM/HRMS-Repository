using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Dtos.Tenant.Organization.OrganizationResponseDtos
{
    public class OrganizationUpdateResponseDto
    {
        public int OrganizationID { get; set; }  // The unique identifier of the updated organization
        public string OrganizationName { get; set; } = string.Empty;  // The updated name of the organization
        public int UpdatedBy { get; set; }  // The ID of the user who performed the update
        public DateTime UpdatedAt { get; set; }  // The timestamp when the organization was updated
        public bool IsActive { get; set; }  // A flag indicating if the organization is active
        public bool IsDelete { get; set; }
    }
}
