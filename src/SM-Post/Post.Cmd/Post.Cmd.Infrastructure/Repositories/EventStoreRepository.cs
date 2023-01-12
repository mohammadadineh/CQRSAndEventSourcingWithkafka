using CQRS.Core.Domain;
using CQRS.Core.Events;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Post.Cmd.Infrastructure.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Cmd.Infrastructure.Repositories
{
    public class EventStoreRepository : IEventStoreRepository
    {
        private readonly IMongoCollection<EventModel> _eventStoreCollection;
        public EventStoreRepository(IOptions<MongoDbConfig> config)
        {
            var mongoClient = new MongoClient(config.Value.ConnectionString);
            var mongoDataBase = mongoClient.GetDatabase(config.Value.DataBase);
            _eventStoreCollection = mongoDataBase.GetCollection<EventModel>(config.Value.Collection);
        }
        public async Task<IEnumerable<EventModel>> FindByAggregateId(Guid aggregateId)
        {
            return (await _eventStoreCollection.FindAsync(x => x.AggregateIdentifire == aggregateId)).ToEnumerable();

        }

        public async Task SaveAsync(EventModel @event)
        {
            await _eventStoreCollection.InsertOneAsync(@event);
        }

        public async Task SaveAsync(IEnumerable<EventModel> events)
        {
            await _eventStoreCollection.InsertManyAsync(events);
        }
    }
}
