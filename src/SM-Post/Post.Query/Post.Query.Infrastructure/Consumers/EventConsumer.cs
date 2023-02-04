using Confluent.Kafka;
using CQRS.Core.Consumers;
using Microsoft.Extensions.Options;
using Post.Query.Infrastructure.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Query.Infrastructure.Consumers
{
    internal class EventConsumer : IEventConsumer
    {
        private readonly ConsumerConfig _config;

        public EventConsumer(IOptions<ConsumerConfig> config)
        {
            _config = config.Value;
        }
        public void Consume(string topic)
        {
            throw new NotImplementedException();
        }
    }
}
