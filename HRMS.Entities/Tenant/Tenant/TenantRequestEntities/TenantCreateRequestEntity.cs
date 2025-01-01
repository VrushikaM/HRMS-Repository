namespace HRMS.Entities.Tenant.Tenant.TenantRequestEntities
{
    public class TenantCreateRequestEntity
    {
        public int OrganizationID { get; set; }
        public int DomainID { get; set; }
        public int SubdomainID { get; set; }
        public string? TenantName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
    }
}
