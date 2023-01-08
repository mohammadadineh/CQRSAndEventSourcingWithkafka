using CQRS.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Common.Events
{
    public class CommentUpdatedEvent : BaseEvent
    {
        public CommentUpdatedEvent(Guid id, int version, Guid commentId,string comment,string userName) : base(id, version, nameof(CommentUpdatedEvent))
        {
            CommentId = commentId;
            Comment = comment;
            UserName = userName;
            EditDate= DateTime.Now; 
        }

        public Guid CommentId { get; private set; }
        public string Comment { get; private set; }
        public string UserName { get; private set; }
        public DateTime EditDate { get; }
    }
}
