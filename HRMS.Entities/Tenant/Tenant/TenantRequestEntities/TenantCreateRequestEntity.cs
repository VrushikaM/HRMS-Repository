﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.Tenant.Tenant.TenantRequestEntities
{
    public class TenantCreateRequestEntity
    {
        public int OrganizationID { get; set; }
        public int DomainID { get; set; }
        public int SubdomainID { get; set; }
        public string? TenantName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; } = false;
        public int CreatedBy { get; set; }

    }
}
