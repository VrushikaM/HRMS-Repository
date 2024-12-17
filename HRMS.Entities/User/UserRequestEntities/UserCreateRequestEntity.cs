namespace HRMS.Entities.User.UserRequestModels
{
    public class UserCreateRequestEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; }
    }
}
