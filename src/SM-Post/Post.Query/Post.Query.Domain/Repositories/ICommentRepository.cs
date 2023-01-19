using Post.Query.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Query.Domain.Repositories
{
    public interface ICommentRepository
    {
        Task CreateAsync(Comment comment);
        Task UpdateAsync(Comment comment);
        Task<Comment?> GetByIdAsync(Guid commentId);
        Task DeleteAsync(Guid commentId);
    }
}
