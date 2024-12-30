using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.Tenant.Organization.OrganizationResponseEntities
{
    public class OrganizationReadResponseEntity
    {
        public int OrganizationID { get; set; }

        public string? OrganizationName { get; set; }

        public int CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }
    
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}
