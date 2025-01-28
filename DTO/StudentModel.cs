namespace DTO
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int RollNumber { get; set; }
        public decimal Fee { get; set; }
    }
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}