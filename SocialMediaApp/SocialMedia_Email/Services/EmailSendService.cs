﻿
using MailKit.Net.Smtp;
using MimeKit;
using SocialMedia_Email.Models;

namespace SocialMedia_Email.Services
{
    public class EmailSendService
    {
        private readonly string email;
        private readonly string password;
        public EmailSendService(IConfiguration _configuration)
        {

            email = _configuration.GetSection("EmailService:Email").Get<string>();
            password = _configuration.GetSection("EmailService:Password").Get<string>();
        }

        public async Task SendEmail(UserMessage res, string message)
        {
            MimeMessage message1 = new MimeMessage();
            message1.From.Add(new MailboxAddress("QuestApp", "jekhyde77@gmail.com"));

            // Set the recipient's email address
            message1.To.Add(new MailboxAddress(res.Name, res.Email));

            message1.Subject = "Welcome to Quest Social App,What thoughts do you have today?";

            var body = new TextPart("html")
            {
                Text = message.ToString()
            };
            message1.Body = body;

            var client = new SmtpClient ();

            client.Connect("smtp.gmail.com", 587, false);

            client.Authenticate("jekhyde77@gmail.com", "vgki lrxb ibfz oglp");

            await client.SendAsync(message1);

            await client.DisconnectAsync(true);
        }
    }
}
