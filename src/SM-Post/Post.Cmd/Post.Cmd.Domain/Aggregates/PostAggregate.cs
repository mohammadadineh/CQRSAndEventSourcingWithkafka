using CQRS.Core.Domain;
using CQRS.Core.Messages;
using Post.Common.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Cmd.Domain.Aggregates
{
    internal class PostAggregate:AggregateRoot
    {
        private readonly Dictionary<Guid, Tuple<string, string>> _comments = new();
        public PostAggregate()
        {

        }
        public PostAggregate(Guid id,string author,string message)
        {
            Id= id;
            Author= author;
            RaiseEvent(new PostCreatedEvent(id,1,author,message));
        }
        public bool Active { get;private set; }
        public string Author { get;private set; }

        public void Apply(PostCreatedEvent @event)
        {
            Id= @event.Id;
            Active = true;
            Author= @event.Author;
        }
        
        public void EditMessage(string message)
        {
            if (!Active)
            {
                throw new InvalidOperationException("You connot edit the message of an inactive post!");
            }
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new InvalidOperationException(
                    $"The value of {nameof(message)} connot be null or empty. Please provide a valid {nameof(message)}!");

            }

            RaiseEvent(new MessageUpdatedEvent(Id, 1, message));
        }

        public void Apply(MessageUpdatedEvent @event)
        {
            Id= @event.Id;
        }
        public void LikePost()
        {
            if (!Active)
            {
                throw new InvalidOperationException("You connot like an inactive post!");
            }
            RaiseEvent(new PostLikedEvent(Id,1));
        }

        public void Apply(PostLikedEvent @event)
        {
            Id= @event.Id;
        }

        public void AddComment(string comment,string userName)
        {
            if (!Active)
            {
                throw new InvalidOperationException("You connot add a comment to an inactive post!");
            }

            if (string.IsNullOrWhiteSpace(comment))
            {
                throw new InvalidOperationException(
                $"The value of {nameof(comment)} connot be null or empty. Please provide a valid {nameof(comment)}!");

            }
            RaiseEvent(new CommentAddedEvent(Id, 1, Guid.NewGuid(), comment, userName));
        }

        public void Apply(CommentAddedEvent @event)
        {
            Id = @event.Id;
            _comments.Add(@event.CommentId, new Tuple<string, string>(@event.Comment, @event.UserName));
        }

        public void EditComment(Guid commentId,string comment)
        {

        }
    }
}
