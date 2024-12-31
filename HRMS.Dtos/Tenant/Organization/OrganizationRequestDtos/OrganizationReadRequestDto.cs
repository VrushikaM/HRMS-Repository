namespace HRMS.Dtos.Tenant.Organization.OrganizationRequestDtos
{
    public class OrganizationReadRequestDto
    {
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
