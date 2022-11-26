namespace MVC.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Role Role { get; set; }
    }

    public enum Role
    {
        Admin = 1,
        User = 2
    }
}
