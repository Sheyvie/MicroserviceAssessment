﻿
using System.Text;
using SocialMedia_Email.Models;
using Newtonsoft.Json;
using Azure.Messaging.ServiceBus;
using SocialMedia_Email.Services;

namespace SocialMedia_Email.Messaging
{
  
     public class AzureMessageBusConsumer : IAzureMessageBusConsumer
     {
            private readonly IConfiguration _configuration;
            private readonly string Connectionstring;
            private readonly string QueueName;
            private readonly ServiceBusProcessor _registrationProcessor;
            private readonly EmailSendService _emailService;
            private readonly EmailService _saveToDb;
        public AzureMessageBusConsumer(IConfiguration configuration, EmailService service)
        {

                _configuration = configuration;
                Connectionstring = _configuration.GetSection("ServiceBus:ConnectionString").Get<string>();

                QueueName = _configuration.GetSection("QueuesandTopics:RegisterUser").Get<string>();

                var serviceBusClient = new ServiceBusClient(Connectionstring);
                _registrationProcessor = serviceBusClient.CreateProcessor(QueueName);
                _emailService = new EmailSendService(_configuration);
                _saveToDb = service;

        }

          
        public async Task Start()
        {
            //start Processor
            _registrationProcessor.ProcessMessageAsync += OnRegistartion;
            _registrationProcessor.ProcessErrorAsync += ErrorHandler;
            await _registrationProcessor.StartProcessingAsync();

            
        }

        

        public async Task Stop()
        {
                //Stop Processor
                await _registrationProcessor.StopProcessingAsync();
                await _registrationProcessor.DisposeAsync();
        }

    

        private Task ErrorHandler(ProcessErrorEventArgs arg)
        {

                //[Todo] send an email to Admin

                throw new NotImplementedException();
        }

        private async Task OnRegistartion(ProcessMessageEventArgs arg)
        {
            var message = arg.Message;

            var body = Encoding.UTF8.GetString(message.Body);

            var userMessage = JsonConvert.DeserializeObject<UserMessage>(body);

            //TODO send An Email
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("<img src=\"https://www.google.com/url?sa=i&url=https%3A%2F%2Fwallpapers.com%2Flove-cute-couple&psig=AOvVaw36sEMvU2itNk2F-llsOo06&ust=1694352291748000&source=images&cd=vfe&opi=89978449&ved=0CBAQjRxqFwoTCKjF86bQnYEDFQAAAAAdAAAAABAE\" width =\"1000\" height=\"600\">");
                stringBuilder.Append("<h1> Hello " + userMessage.Name + "</h1>");
                stringBuilder.AppendLine("<br/>Welcome to Quest World ");

                stringBuilder.Append("<br/>");
                stringBuilder.Append('\n');
                stringBuilder.Append("<p> Post your Thoughts here here</p>");
                var emailLogger = new EmailLoggers()
                {
                    Email = userMessage.Email,
                    Message = stringBuilder.ToString()

                };
                await _saveToDb.SaveData(emailLogger);
                await _emailService.SendEmail(userMessage, stringBuilder.ToString());
                //you can delete the message from the queue
                await arg.CompleteMessageAsync(message);
            }
            catch (Exception ex) 
            {
            }
        }

    }
}
