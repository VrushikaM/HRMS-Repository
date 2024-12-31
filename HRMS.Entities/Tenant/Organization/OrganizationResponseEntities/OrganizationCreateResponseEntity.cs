namespace HRMS.Entities.Tenant.Organization.OrganizationResponseEntities
{
    public class OrganizationCreateResponseEntity
    {
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; } = String.Empty;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool ISDelete { get; set; }
    }
}
