namespace HRMS.Dtos.Tenant.TenancyRole.TenancyRoleRequestDtos
{
    public class TenancyRoleCreateRequestDto
    {
        public string RoleName { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
