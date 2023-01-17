using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Query.Domain.Entities
{
    public class Post
    {
        private Post() { }
        public Guid Id { get;private set; }
        public string Author { get;private set; }
        public DateTime DatePosted { get;private set; }
        public string Message { get;private set; }
        public int Likes { get;private set; }

        public virtual IEnumerable<Comment>  Comments { get;private set; }
    }
}
