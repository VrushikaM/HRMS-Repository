namespace HRMS.Dtos.Tenant.Organization.OrganizationResponseDtos
{
    public class OrganizationCreateResponseDto
    {
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
