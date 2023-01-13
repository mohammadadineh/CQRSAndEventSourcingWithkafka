﻿using CQRS.Core.Domain;
using CQRS.Core.Handlers;
using CQRS.Core.Infrastructure;
using Post.Cmd.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Cmd.Infrastructure.Handlers
{
    public class EventSourcingHandler : IEventSourcingHandler<PostAggregate>
    {
        private readonly IEventStore _eventStore;
        public EventSourcingHandler(IEventStore eventStore)
        {
            _eventStore= eventStore;
        }
        public async Task<PostAggregate> GetByIdAsync(Guid aggregateId)
        {
            var aggregate=new PostAggregate();
            var events=await _eventStore.GetEventsAsync(aggregateId);
            if (events is null || !events.Any())
            {
                return aggregate;
            }

            aggregate.ReplayEvents(events);
            var lastVersion = events.Select(e => e.Version).Max();
            aggregate.ChangeOrSetVersion(lastVersion);

            return aggregate;
        }

        public async Task SaveAsync(AggregateRoot aggregate)
        {
            await _eventStore.SaveEventAsync(aggregate.Id, aggregate.GetUncommittedChanges(), aggregate.Version);
            aggregate.MarkChangesAsCommitted();
        }
    }
}
