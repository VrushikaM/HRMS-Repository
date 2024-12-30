using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Dtos.Tenant.Organization.OrganizationRequestDtos
{
    public class OrganizationReadRequestDto
    {
        public int OrganizationID { get; set; }
        public string? OrganizationName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
