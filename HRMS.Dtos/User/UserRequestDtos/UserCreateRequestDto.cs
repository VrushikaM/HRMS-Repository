namespace HRMS.Dtos.User.UserRequestModels
{
    public class UserCreateRequestDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; }
    }
}
