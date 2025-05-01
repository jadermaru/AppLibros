using System.Security.Claims;

namespace BackendLibreria.Interface
{
    public interface ITokenService
    {
        Task<string> AuthenticateAsync(string username, string password);
    }
}
