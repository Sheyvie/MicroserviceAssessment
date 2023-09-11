using SocialMedia_Email.Messaging;

namespace SocialMedia_Email.Extensions
{
    public static class AzureServiceStarter
    {
        public static IAzureMessageBusConsumer ServiceBusConsumerInstance { get; set; }
        public static IApplicationBuilder useAzure(this IApplicationBuilder app)
        {
            ServiceBusConsumerInstance = app.ApplicationServices.GetService<IAzureMessageBusConsumer>();

            var HostLifetime = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            HostLifetime.ApplicationStarted.Register(OnStart);
            HostLifetime.ApplicationStopping.Register(OnStop);

            return app;
        }

        private static void OnStop()
        {
            //Stop Email Processor
            ServiceBusConsumerInstance.Stop();
        }

        private static void OnStart()
        {
            //Call Email Processor
            ServiceBusConsumerInstance.Start();
        }
    }
}
