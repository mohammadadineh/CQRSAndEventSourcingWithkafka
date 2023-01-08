using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands
{
    internal class AddCommentCommand : BaseCommand
    {
        internal AddCommentCommand(Guid id, string comment, string userName) : base(id)
        {
            Comment = comment;
            UserName = userName;
        }
        public string Comment { get; private set; }
        public string UserName { get; private set; }
    }
}
