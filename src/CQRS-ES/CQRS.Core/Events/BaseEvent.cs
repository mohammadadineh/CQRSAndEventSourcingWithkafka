using CQRS.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Core.Events
{
    public abstract class BaseEvent : Message
    {
        protected BaseEvent(Guid id,int version,string type) : base(id)
        {
            Version = version;
            Type = type;
        }

        public int Version { get;private set; }
        public string Type { get;private set; }
    }
}
