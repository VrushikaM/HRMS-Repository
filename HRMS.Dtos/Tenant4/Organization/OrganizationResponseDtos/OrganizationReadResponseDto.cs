using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Dtos.Tenant.Organization.OrganizationResponseDtos
{
    public class OrganizationReadResponseDto
    {
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }  // Nullable because UpdatedBy can be null
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
