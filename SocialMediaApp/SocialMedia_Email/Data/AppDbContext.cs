using Microsoft.EntityFrameworkCore;
using SocialMedia_Email.Models;

namespace SocialMedia_Email.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<EmailLoggers> EmailLoggers { get; set; }
    }
}
