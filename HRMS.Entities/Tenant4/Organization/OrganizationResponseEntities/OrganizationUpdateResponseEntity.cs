using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.Tenant.Organization.OrganizationResponseEntities
{
    public class OrganizationUpdateResponseEntity
    {
        public int OrganizationID { get; set; }  
        public string OrganizationName { get; set; } = string.Empty;
        public int UpdatedBy { get; set; }
        public DateTime UpdatedaAt { get; set; }
        public bool IsActive { get; set; }
    }
}
