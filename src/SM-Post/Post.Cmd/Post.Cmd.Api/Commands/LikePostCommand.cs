using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands
{
    internal class LikePostCommand : BaseCommand
    {
        internal LikePostCommand(Guid id) : base(id)
        {
        }
    }
}
