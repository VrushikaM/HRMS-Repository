namespace HRMS.Entities.Tenant.TenancyRole.TenancyRoleRequestEntities
{
    public class TenancyRoleCreateRequestEntity
    {
        public string RoleName { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
