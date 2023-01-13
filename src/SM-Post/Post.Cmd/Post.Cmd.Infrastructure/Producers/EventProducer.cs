using Confluent.Kafka;
using CQRS.Core.Events;
using CQRS.Core.Producers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Post.Cmd.Infrastructure.Producers
{
    public class EventProducer : IEventProducer
    {
        private readonly ProducerConfig _config;
        public EventProducer(IOptions<ProducerConfig> config)
        {
            _config = config.Value;
        }
        public async Task ProduceAsync<T>(string topic, T @event) where T : BaseEvent
        {
            using var producer =new ProducerBuilder<string,string>(_config)
                .SetKeySerializer(Serializers.Utf8)
                .SetValueSerializer(Serializers.Utf8)
                .Build();

            var eventMessage = new Message<string, string>
            {
                Key = Guid.NewGuid().ToString(),
                Value = JsonSerializer.Serialize(@event, @event.GetType())
            };

            var deliveryResult=await producer.ProduceAsync(topic, eventMessage);
            if (deliveryResult.Status==PersistenceStatus.NotPersisted)
            {
                throw new Exception($"Could not produce{@event.GetType().Name} message to topic." +
                                    $" {topic} due to the following reason: {deliveryResult.Message}.");
            }
        }

        public async Task ProduceAsync<T>(string topic, IEnumerable<T> @event) where T : BaseEvent
        {
            using var producer = new ProducerBuilder<string, string>(_config)
                .SetKeySerializer(Serializers.Utf8)
                .SetValueSerializer(Serializers.Utf8)
                .Build();

            foreach (var message in @event)
            {
                var eventMessage = new Message<string, string>
                {
                    Key = Guid.NewGuid().ToString(),
                    Value = JsonSerializer.Serialize(message, message.GetType())
                };

                var deliveryResult = await producer.ProduceAsync(topic, eventMessage);
                if (deliveryResult.Status == PersistenceStatus.NotPersisted)
                {
                    throw new Exception($"Could not produce{message.GetType().Name} message to topic." +
                                        $" {topic} due to the following reason: {deliveryResult.Message}.");
                }
            }



        }
    }
}
