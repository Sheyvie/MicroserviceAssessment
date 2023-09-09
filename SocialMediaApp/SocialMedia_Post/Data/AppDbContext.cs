using Microsoft.EntityFrameworkCore;
using SocialMedia_Post.Models;

namespace SocialMedia_Post.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Posts> Posts { get; set; }
    }
}
