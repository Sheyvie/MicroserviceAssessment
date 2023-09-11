using Microsoft.EntityFrameworkCore;
using SocialMedia_Email.Data;
using SocialMedia_Email.Models;

namespace SocialMedia_Email.Services
{
    public class EmailService
    {
        private DbContextOptions<AppDbContext> options;

        public EmailService()
        {
        }

        public EmailService(DbContextOptions<AppDbContext> options)
        {
            this.options = options;
        }


        public async Task SaveData(EmailLoggers emailLoggers)
        {
            

            var _context = new AppDbContext(this.options);
            _context.EmailLoggers.Add(emailLoggers);
            await _context.SaveChangesAsync();
        }
    }
}
