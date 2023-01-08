using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands
{
    internal class DeletePostCommand : BaseCommand
    {
        internal DeletePostCommand(Guid id, string userName) : base(id)
        {
            UserName = userName;
        }
        public string UserName { get; private set; }
    }
}
