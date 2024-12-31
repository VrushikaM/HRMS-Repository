namespace HRMS.Dtos.Tenant.TenancyRole.TenancyRoleRequestDtos
{
    public class TenancyRoleUpdateRequestDto
    {
        public int TenancyRoleID { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public int UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
