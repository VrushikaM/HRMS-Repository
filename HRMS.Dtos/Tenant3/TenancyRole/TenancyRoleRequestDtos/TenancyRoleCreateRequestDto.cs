namespace HRMS.Dtos.Tenant3.TenancyRole.TenancyRoleRequestDtos
{
    public class TenancyRoleCreateRequestDto
    {
        public string RoleName { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

    }
}
