namespace HRMS.Dtos.Tenant.Subdomain.SubdomainRequestDto
{
    public class SubdomainUpdateRequestDto
    {
        public int SubdomainID { get; set; }
        public int DomainID { get; set; }
        public string SubdomainName { get; set; } = string.Empty;
        public int UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
