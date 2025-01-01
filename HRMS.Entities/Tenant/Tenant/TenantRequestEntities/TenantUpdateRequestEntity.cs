namespace HRMS.Entities.Tenant.Tenant.TenantRequestEntities
{
    public class TenantUpdateRequestEntity
    {
        public int TenantID { get; set; }
        public int OrganizationID { get; set; }
        public int DomainID { get; set; }
        public int SubdomainID { get; set; }
        public string? TenantName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int UpdatedBy { get; set; }
    }
}
