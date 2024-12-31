﻿namespace HRMS.Dtos.User.User.UserRequestDtos
{
    public class UserUpdateRequestDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int UpdatedBy { get; set; }
        public int TenantID { get; set; }
        public int RoleID { get; set; }
        public int TenancyRoleID { get; set; }
    }
}