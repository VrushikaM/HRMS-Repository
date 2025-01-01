namespace HRMS.Entities.Tenant.Subdomain.SubdomainRequestEntites
{
    public class SubdomainCreateRequestEntity
    {
        public int DomainId { get; set; }
        public string SubdomainName { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
