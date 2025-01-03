﻿namespace HRMS.Dtos.Tenant.Subdomain.SubdomainRequestDto
{
    public class SubdomainCreateRequestDto
    {
        public int DomainId { get; set; }
        public string SubdomainName { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
