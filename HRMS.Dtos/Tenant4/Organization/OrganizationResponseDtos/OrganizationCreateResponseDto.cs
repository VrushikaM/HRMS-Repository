using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Dtos.Tenant.Organization.OrganizationResponseDtos
{
    public class OrganizationCreateResponseDto
    {
        public int OrganizationID { get; set; }  // The ID of the newly created organization
        public string OrganizationName { get; set; }  // The name of the organization
        public int CreatedBy { get; set; }  // The user ID of who created the organization
        public DateTime CreatedAt { get; set; }  // The timestamp of when the organization was created
        public bool IsActive { get; set; }  // A flag indicating if the organization is active
        public bool IsDelete { get; set; }
    }
}
