namespace ServerApp.Models
{
    public class User
    {
        public int ID { get; set; }       // Unique ID for each user
        public string? Name { get; set; }  // Full name of the user
        public string? Email { get; set; } // Email address
        public string? Password { get; set; } // User's password (should be hashed in real apps)
    }
}