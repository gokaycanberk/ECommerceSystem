namespace UserService.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty; // Non-nullable property initialization
        public string Email { get; set; } = string.Empty; // Non-nullable property initialization
    }
}
