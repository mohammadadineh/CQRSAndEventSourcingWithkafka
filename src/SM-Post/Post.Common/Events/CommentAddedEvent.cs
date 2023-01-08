using CQRS.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Common.Events
{
    public class CommentAddedEvent : BaseEvent
    {
        public CommentAddedEvent(Guid id, int version, Guid commentId, string comment, string userName) : base(id, version, nameof(CommentAddedEvent))
        {
            CommentId = commentId;
            Comment = comment;
            UserName = userName;
            CommentDate= DateTime.Now;
        }

        public Guid CommentId { get;private set; }
        public string Comment { get;private set; }
        public string UserName { get;private set; }
        public DateTime CommentDate { get; }
    }
}
