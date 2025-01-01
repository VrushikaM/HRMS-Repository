namespace HRMS.Dtos.User.User.UserRequestDtos
{
    public class UserCreateRequestDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int TenantId { get; set; }
        public int RoleId { get; set; }
        public int TenancyRoleId { get; set; }
    }
}