namespace HRMS.Dtos.Tenant3.TenancyRole.TenancyRoleRequestDtos
{
    public class TenancyRoleUpdateRequestDto
    {
        public int TenancyRoleID { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

    }
}
