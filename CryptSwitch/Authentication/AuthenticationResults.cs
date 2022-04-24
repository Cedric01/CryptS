namespace CryptSwitch.Authentication
{
    public class AuthenticationResults
    {
        public string token { get; set; }
        public bool Success { get; set; }

        public IEnumerable<string> ErrorMessages { get; set; }
    }
}
