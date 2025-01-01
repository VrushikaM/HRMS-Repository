namespace HRMS.Dtos.Tenant.Tenant.TenantRequestDtos
{
    public class TenantCreateRequestDtos
    {
        public int OrganizationID { get; set; }
        public int DomainID { get; set; }
        public int SubdomainId { get; set; }
        public string? TenantName { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
