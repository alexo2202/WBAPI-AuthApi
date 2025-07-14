namespace Application.MediatR.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordKey { get; set; }
        public int RoleId { get; set; }
        public int EmployeeId { get; set; }
    }
}
