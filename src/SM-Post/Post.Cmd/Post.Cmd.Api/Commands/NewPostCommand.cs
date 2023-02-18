using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands
{
    public class NewPostCommand : BaseCommand
    {
       
        internal NewPostCommand(Guid id, string author,string message) : base(id)
        {
            Author = author;
            Message = message;
        }

        public string Author { get;private set; }
        public string Message { get;private set; }
    }
}
