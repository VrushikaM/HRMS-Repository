﻿namespace HRMS.Entities.Tenant.Subdomain.SubdomainResponseEntites
{
    public class SubdomainReadResponseEntity
    {
        public int SubdomainID { get; set; }
        public int DomainID { get; set; }
        public string SubdomainName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}