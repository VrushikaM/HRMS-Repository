﻿namespace HRMS.Dtos.User.UserRoles.UserRolesResponseDtos
{
    public class UserRolesUpdateResponseDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public int PermissionGroupId { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
