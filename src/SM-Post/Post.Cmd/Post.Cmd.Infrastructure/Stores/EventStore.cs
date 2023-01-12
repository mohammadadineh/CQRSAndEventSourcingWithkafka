using CQRS.Core.Domain;
using CQRS.Core.Events;
using CQRS.Core.Exceptions;
using CQRS.Core.Infrastructure;
using Post.Cmd.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Cmd.Infrastructure.Stores
{
    public class EventStore : IEventStore
    {
       private readonly IEventStoreRepository _eventStoreRepository;
        public EventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public async Task<IEnumerable<BaseEvent>> GetEventsAsync(Guid aggregateId)
        {
           var eventStream=await _eventStoreRepository.FindByAggregateId(aggregateId);
            if (eventStream is null || !eventStream.Any())
            {
                throw new AggregateNotFoundException("Incorrect post ID provided!");
            }

            return eventStream.OrderBy(e=>e.Version).Select(e=>e.EventData);
        }

        public async Task SaveEventAsync(Guid aggregateId, IEnumerable<BaseEvent> events, int expectedVersion)
        {
            var eventStream = await _eventStoreRepository.FindByAggregateId(aggregateId);
            if (expectedVersion != -1 && eventStream.LastOrDefault()?.Version != expectedVersion)
            {
                throw new ConcurrencyException();
            }
            var version = expectedVersion;
            IEnumerable<EventModel> eventModels= new List<EventModel>();
            foreach (var @event  in events)
            {
                version++;
                var eventModel = new EventModel 
                {
                    TimeStamp = DateTime.Now,
                    AggregateIdentifire=aggregateId,
                    AggregateType=nameof(PostAggregate) ,
                    Version=version,
                    EventType=@event.GetType().Name,
                    EventData=@event
                };  
                
                eventModels.Append(eventModel);

            }
            await _eventStoreRepository.SaveAsync(eventModels);
        }
    }
}
