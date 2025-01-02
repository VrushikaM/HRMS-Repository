namespace HRMS.Entities.Tenant.Subdomain.SubdomainRequestEntites
{
    public class SubdomainUpdateRequestEntity
    {
        public int SubdomainId { get; set; }
        public int DomainId { get; set; }
        public string SubdomainName { get; set; } = string.Empty;
        public int UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
