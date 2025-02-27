namespace sga.AuthService.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Status { get; set; }
    }
}
