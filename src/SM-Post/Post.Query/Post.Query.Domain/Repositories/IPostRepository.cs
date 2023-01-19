using Post.Query.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Query.Domain.Repositories
{
    public interface IPostRepository
    {
        Task CreateAsync(Entities.Post post);
        Task UpdateAsync(Entities.Post post);
        Task DeleteAsync(Guid postId);
        ValueTask<Entities.Post?> GetByIdAsync(Guid postId);
        Task<IEnumerable<Entities.Post>> GetAllAsync(); 
        Task<IEnumerable<Entities.Post>> GetByAuthorAsync(string author);
        Task<IEnumerable<Entities.Post>> GetWithLikesAsync(int numberOfLikes);
        Task<IEnumerable<Entities.Post>> GetWithCommentsAsync();
        

    }
}
