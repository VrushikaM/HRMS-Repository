namespace HRMS.Entities.Tenant3.TenancyRole.TenancyRoleRequestEntities
{
    public class TenancyRoleCreateRequestEntity
    {
        public string RoleName { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
    }
}
