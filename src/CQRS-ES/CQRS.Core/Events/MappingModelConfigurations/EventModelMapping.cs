
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Core.Events.MappingModelConfigurations
{

    public static class EventModelMapping
    {
        public static void Mapping()
        {
            BsonClassMap.RegisterClassMap<EventModel>(cm =>
            {
                
                cm.MapIdMember(p => p.Id);
                cm.MapMember(c => c.Id).SetSerializer(new CharSerializer(BsonType.ObjectId));
                cm.MapProperty(c => c.TimeStamp);
                cm.MapProperty(c => c.AggregateIdentifire);
                cm.MapProperty(c => c.AggregateType);
                cm.MapProperty(c => c.Version);
                cm.MapProperty(c => c.EventType);
                cm.MapProperty(c => c.EventData);
            });
        }

    }
}
