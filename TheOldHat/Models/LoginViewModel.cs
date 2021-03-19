namespace TheOldHat.Models
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public string Error { get; set; }
        public bool Failed => !string.IsNullOrWhiteSpace(Error);

        public LoginViewModel()
        {
            Email = string.Empty;
            Password = string.Empty;
            ReturnUrl = string.Empty;
            Error = string.Empty;
        }
    }
}