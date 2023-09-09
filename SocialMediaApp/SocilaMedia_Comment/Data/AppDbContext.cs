using Microsoft.EntityFrameworkCore;
using SocilaMedia_Comment.Models;

namespace SocialMedia_Comment.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Comments> Comments{ get; set; }
    }
}
