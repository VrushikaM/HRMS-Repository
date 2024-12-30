using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.Tenant.Organization.OrganizationRequestEntities
{
    public class OrganizationCreateRequestEntity
    {
        public string OrganizationName { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDelete { get; set; } = false;

    }
}
