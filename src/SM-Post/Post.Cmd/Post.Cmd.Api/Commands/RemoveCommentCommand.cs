using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands
{
    internal class RemoveCommentCommand : BaseCommand
    {
        internal  RemoveCommentCommand(Guid id, Guid commentId, string userName) : base(id)
        {
            CommentId = commentId;
            UserName = userName;
        }
        public Guid CommentId { get; private set; }
        public string UserName { get; private set; }
    }
}
