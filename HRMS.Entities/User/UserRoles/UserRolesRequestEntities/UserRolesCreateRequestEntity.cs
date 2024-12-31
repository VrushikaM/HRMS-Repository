namespace HRMS.Entities.User.UserRoles.UserRolesRequestEntities
{
    public class UserRolesCreateRequestEntity
    {
        public string RoleName { get; set; } = string.Empty;
        public int PermissionGroupId { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
