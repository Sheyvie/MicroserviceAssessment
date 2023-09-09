using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaMessageApp
{
    public class MessageBus : IMessageBus
    {
        public string ConnectionString = "Endpoint=sb://yvieenterprise.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=c1mRQF80/fmvWtzFAfjEjrgNHAnzaQwgA+ASbMNGHNU=";
        public async Task PublishMessage(object message, string queue)
        {

            var serviceBus = new ServiceBusClient(this.ConnectionString);
            var sender = serviceBus.CreateSender(queue);

            var jsonMessage = JsonConvert.SerializeObject(message);

            var theMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
            {

                //Give a unique iDentifier
                CorrelationId = Guid.NewGuid().ToString(),
            };


            //send the Message
            await sender.SendMessageAsync(theMessage);
            //clean up Resource
            await serviceBus.DisposeAsync();
        }
    }
}

