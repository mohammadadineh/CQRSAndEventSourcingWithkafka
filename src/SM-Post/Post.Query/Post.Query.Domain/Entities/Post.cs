using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Query.Domain.Entities
{
    public class Post
    {
        public Post(Guid id, string author, DateTime datePosted, string message)
        {
            Id = id;
            Author = author;
            DatePosted = datePosted;
            Message = message;
        }
        public Guid Id { get;private set; }
        public string Author { get;private set; }
        public DateTime DatePosted { get;private set; }
        public string Message { get;private set; }
        public int Likes { get;private set; }

        public void UpdateMessage(string message)
        {
            Message = message;
        }
        public void PostLiked()
        {
            Likes++;
        }
        public void AddComment(Comment comment, Guid postId=(default))
        {
            if (postId!=default)
            {
                Id = postId;
            }
            Comments.Add(comment);
        }
        public virtual ICollection<Comment> Comments { get; private set; } = new List<Comment>();
    }
}
