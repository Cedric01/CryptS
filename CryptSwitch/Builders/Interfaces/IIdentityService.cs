using CryptSwitch.Authentication;

namespace CryptSwitch.Builders.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthenticationResults>Register(string email, string password);
    }
}
