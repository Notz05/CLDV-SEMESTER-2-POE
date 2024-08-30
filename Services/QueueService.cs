using Azure.Storage.Queues;
using System.Threading.Tasks;

namespace ABCRetailWebApp.Services
{
    public class QueueService
    {
        private readonly QueueServiceClient _queueServiceClient;

        public QueueService(QueueServiceClient queueServiceClient)
        {
            _queueServiceClient = queueServiceClient;
        }

        public async Task SendMessageAsync(string queueName, string message)
        {
            var queueClient = _queueServiceClient.GetQueueClient(queueName);
            await queueClient.CreateIfNotExistsAsync();
            await queueClient.SendMessageAsync(message);
        }
    }
}
