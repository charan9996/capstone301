using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using MT.OnlineRestaurant.BusinessLayer.interfaces;
using MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel;
using MT.OnlineRestaurant.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MT.OnlineRestaurant.BusinessLayer
{
    public class AzureBus : IAzureBus
    {
        private static string _serviceBusConnectionString;
        private static string _subscriptionNameToRecieve;
        private static string _topicNameToRecieve;
        private static string _subscriptionNameToSend;
        private static string _topicNameToSend;
        private static ISearchRepository _searchRepository;
        static ISubscriptionClient subscriptionClient;
        static List<string> listOfMessagesfromQueue = new List<string>();
        static ITopicClient topicClient;
        static TblMenu StockDeails;
        static string CallBackMessagetoBeSent = string.Empty;


        public AzureBus(IConfiguration config, ISearchRepository searchRepository)
        {
            _serviceBusConnectionString = config["AzureServiceBus:ConnectionString"];
            _topicNameToRecieve = config["TopicName:TopicNameStringtoRecieve"];
            _subscriptionNameToRecieve = config["Subscription:SubsriptionStringRecieve"];
            _topicNameToSend = config["TopicName:TopicNameString"];
            _subscriptionNameToSend = config["Subscription:SubscriptionString"];
            //  _topicName = config["TopicName:TopicNameString"];
            _searchRepository = searchRepository;
        }
        public void AzureServiceBus()
        {


            subscriptionClient = new SubscriptionClient(_serviceBusConnectionString, _topicNameToRecieve, _subscriptionNameToRecieve);
            topicClient = new TopicClient(_serviceBusConnectionString, _topicNameToSend);
            RegisterOnMessageHandlerAndReceiveMessages();


            //if (StockDeails.Item == null)
            //    CallBackMessagetoBeSent = "Invalid Combination of ResturantId and MenuId";
            //else

        }



        static void RegisterOnMessageHandlerAndReceiveMessages()
        {
            // Configure the message handler options in terms of exception handling, number of concurrent messages to deliver, etc.
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                // Maximum number of concurrent calls to the callback ProcessMessagesAsync(), set to 1 for simplicity.
                // Set it according to how many messages the application wants to process in parallel.
                MaxConcurrentCalls = 1,

                // Indicates whether the message pump should automatically complete the messages after returning from user callback.
                // False below indicates the complete operation is handled by the user callback as in ProcessMessagesAsync().
                AutoComplete = false
            };

            // Register the function that processes messages.
            subscriptionClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);


        }
        static async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            // Process the message.
            string s = Encoding.UTF8.GetString(message.Body);
            listOfMessagesfromQueue.Add(s);
            // Complete the message so that it is not received again.
            // This can be done only if the subscriptionClient is created in ReceiveMode.PeekLock mode (which is the default).
            await subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
            if (listOfMessagesfromQueue.Count == 2)
            {
                StockDeails = _searchRepository.GetStockDetails(int.Parse(listOfMessagesfromQueue[0]), int.Parse(listOfMessagesfromQueue[1]));
                CallBackMessagetoBeSent = StockDeails.quantity.ToString();
                message = new Message(Encoding.UTF8.GetBytes(CallBackMessagetoBeSent));



                // Send the message to the topic
                await topicClient.SendAsync(message);

                listOfMessagesfromQueue = new List<string>();


            }
            // Note: Use the cancellationToken passed as necessary to determine if the subscriptionClient has already been closed.
            // If subscriptionClient has already been closed, you can choose to not call CompleteAsync() or AbandonAsync() etc.
            // to avoid unnecessary exceptions.
        }
        static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            //Console.WriteLine($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
            //var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
            //Console.WriteLine("Exception context for troubleshooting:");
            //Console.WriteLine($"- Endpoint: {context.Endpoint}");
            //Console.WriteLine($"- Entity Path: {context.EntityPath}");
            //Console.WriteLine($"- Executing Action: {context.Action}");
            return Task.CompletedTask;
        }
    }
}
