using backend.domain.Entities;

namespace backend.app.Interfaces.Services
{
    public interface ITokenService
    {
        // Task<string> CreateTokenAsync(AppUser user);
        string CreateTokenAsync(AppUser user);
    }
}