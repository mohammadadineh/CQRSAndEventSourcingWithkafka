using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands
{
    internal class EditMessageCommand : BaseCommand
    {
        internal EditMessageCommand(Guid id, string message) : base(id)
        {
            Message = message;
        }

        public string Message { get; private set; }

    }

}