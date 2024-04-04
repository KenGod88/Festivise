using Festivise.Schedules.Storage.Contracts;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Festivise.Schedules.Storage
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ScheduleRepositoryOptions _options;

        public ScheduleRepository(IOptions<ScheduleRepositoryOptions> options)
        {
            _options = options.Value;
        }
        public async Task<ScheduleModel> CreateScheduleAsync(ScheduleModel schedule)
        {
            CosmosClient client = new CosmosClient(_options.ConnectionString);
            Database database = client.GetDatabase("Festivise");

            ContainerProperties containerProperties = new ContainerProperties()
            {
                Id = "Schedules",
                PartitionKeyPath = "/id"
            };

            Container container = await database.CreateContainerIfNotExistsAsync(containerProperties);

            return await container.CreateItemAsync<ScheduleModel>(schedule, new PartitionKey(schedule.id));
        }

        public async Task<ScheduleModel> GetScheduleAsync(string id)
        {
            CosmosClient client = new CosmosClient(_options.ConnectionString);
            Database database = client.GetDatabase("Festivise");

            ContainerProperties containerProperties = new ContainerProperties()
            {
                Id = "Schedules",
                PartitionKeyPath = "/id"
            };

            Container container = await database.CreateContainerIfNotExistsAsync(containerProperties);

            try
            {
                return await container.ReadItemAsync<ScheduleModel>(id, new PartitionKey(id));
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }
    }
}
