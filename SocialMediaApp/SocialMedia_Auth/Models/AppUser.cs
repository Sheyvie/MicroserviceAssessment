using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace SocialMedia_Auth.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
