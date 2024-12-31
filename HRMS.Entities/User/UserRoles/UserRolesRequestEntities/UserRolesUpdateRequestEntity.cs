namespace HRMS.Entities.User.UserRoles.UserRolesRequestEntities
{
    public class UserRolesUpdateRequestEntity
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public int PermissionGroupId { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
