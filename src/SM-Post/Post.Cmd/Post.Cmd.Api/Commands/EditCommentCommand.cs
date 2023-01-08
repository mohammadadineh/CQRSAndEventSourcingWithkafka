using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands
{
    internal class EditCommentCommand : BaseCommand
    {
        internal EditCommentCommand(Guid id, Guid commentId,string comment, string userName) : base(id)
        {
            CommentId = commentId;
            Comment = comment;
            UserName = userName;
        }
        public Guid CommentId { get;private set; }
        public string Comment { get;private set; }
        public string UserName { get;private set; }
    }
}
