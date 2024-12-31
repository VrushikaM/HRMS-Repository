namespace HRMS.Dtos.Tenant.Organization.OrganizationRequestDtos
{
    public class OrganizationCreateRequestDto
    {
        public string OrganizationName { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
