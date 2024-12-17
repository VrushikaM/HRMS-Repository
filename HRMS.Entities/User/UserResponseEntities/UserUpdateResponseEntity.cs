namespace HRMS.Entities.User.UserResponseEntities
{
    public class UserUpdateResponseEntity
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; }
    }
}
