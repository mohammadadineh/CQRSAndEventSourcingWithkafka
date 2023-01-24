using Post.Common.Events;
using Post.Query.Domain.Entities;
using Post.Query.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostNamespace = Post.Query.Domain.Entities;
namespace Post.Query.Infrastructure.Handlers
{
    internal class EventHandler : IEventHandler
    {
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;

        public EventHandler(IPostRepository postRepository, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }

        public async Task On(PostCreatedEvent @event)
        {
            var post = new PostNamespace.Post(@event.Id, @event.Author, @event.DatePosted, @event.Message);
            await _postRepository.CreateAsync(post);
        }

        public async Task On(MessageUpdatedEvent @event)
        {
            var post = await _postRepository.GetByIdAsync(@event.Id);
            if (post is null) return;
            post.UpdateMessage(@event.Message);
            await _postRepository.UpdateAsync(post);
        }

        public async Task On(PostLikedEvent @event)
        {
            var post = await _postRepository.GetByIdAsync(@event.Id);
            if (post is null) return;
            post.PostLiked();
            await _postRepository.UpdateAsync(post);
        }

        public Task On(CommentAddedEvent @event)
        {
            throw new NotImplementedException();
        }

        public Task On(CommentUpdatedEvent @event)
        {
            throw new NotImplementedException();
        }

        public Task On(CommentRemovedEvent @event)
        {
            throw new NotImplementedException();
        }

        public Task On(PostRemovedEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
