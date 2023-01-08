using CQRS.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Common.Events
{
    public class PostCreatedEvent : BaseEvent
    {
        public PostCreatedEvent(Guid id, int version, string author, string message, DateTime datePosted) : base(id, version, nameof(PostCreatedEvent))
        {
            Author = author;
            Message = message;
            DatePosted = datePosted;
        }

        public string Author { get;private set; }
        public string Message { get;private set; }
        public DateTime DatePosted { get;private set; }
    }
}
