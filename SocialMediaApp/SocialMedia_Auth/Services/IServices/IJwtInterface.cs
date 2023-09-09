using SocialMedia_Auth.Models;

namespace SocialMedia_Auth.Services.IServices
{
    public interface IJwtInterface
    {
        string GenerateToken(AppUser user, IEnumerable<string> roles);
    }
}
