using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMedia_Auth.Models;
using Microsoft.AspNetCore.Identity;

namespace SocialMedia_Auth.Data
{
     //using identity framework core
        public class AppDbContext:IdentityDbContext<AppUser>
        {

           public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

           public DbSet<AppUser> AppUsers { get; set; }

        }
    
}
