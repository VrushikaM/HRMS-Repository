namespace HRMS.Dtos.User.UserRoles.UserRolesRequestDtos
{
    public class UserRolesUpdateRequestDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public int PermissionGroupId { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
