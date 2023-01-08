using CQRS.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Common.Events
{
    public class CommentRemovedEvent : BaseEvent
    {
        public CommentRemovedEvent(Guid id, int version, Guid commentId) : base(id, version, nameof(CommentRemovedEvent))
        {
            CommentId = commentId;
        }

        public Guid CommentId { get; private set; }
    }
}
