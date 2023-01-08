using CQRS.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Common.Events
{
    public class PostLikedEvent : BaseEvent
    {
        public PostLikedEvent(Guid id, int version) : base(id, version, nameof(PostLikedEvent))
        {
        }
    }
}
