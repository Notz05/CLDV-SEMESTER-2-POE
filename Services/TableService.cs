using Azure.Data.Tables;
using System.Threading.Tasks;

namespace ABCRetailWebApp.Services
{
    public class TableService
    {
        private readonly TableServiceClient _tableServiceClient;

        public TableService(TableServiceClient tableServiceClient)
        {
            _tableServiceClient = tableServiceClient;
        }

        public async Task AddEntityAsync<T>(string tableName, T entity) where T : class, ITableEntity, new()
        {
            var tableClient = _tableServiceClient.GetTableClient(tableName);
            await tableClient.CreateIfNotExistsAsync();
            await tableClient.AddEntityAsync(entity);
        }

        public async Task<T> GetEntityAsync<T>(string tableName, string partitionKey, string rowKey) where T : class, ITableEntity, new()
        {
            var tableClient = _tableServiceClient.GetTableClient(tableName);
            var entity = await tableClient.GetEntityAsync<T>(partitionKey, rowKey);
            return entity.Value;
        }

        public async Task UpdateEntityAsync<T>(string tableName, T entity) where T : class, ITableEntity, new()
        {
            var tableClient = _tableServiceClient.GetTableClient(tableName);
            await tableClient.UpdateEntityAsync(entity, entity.ETag, TableUpdateMode.Replace);
        }

        public async Task DeleteEntityAsync<T>(string tableName, T entity) where T : class, ITableEntity, new()
        {
            var tableClient = _tableServiceClient.GetTableClient(tableName);
            await tableClient.DeleteEntityAsync(entity.PartitionKey, entity.RowKey, entity.ETag);
        }
    }
}
