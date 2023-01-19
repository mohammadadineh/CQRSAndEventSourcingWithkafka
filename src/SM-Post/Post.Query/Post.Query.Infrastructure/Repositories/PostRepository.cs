using Microsoft.EntityFrameworkCore;
using Post.Query.Domain.Entities;
using Post.Query.Domain.Repositories;
using Post.Query.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Post.Query.Infrastructure.Repositories
{
    internal class PostRepository : IPostRepository
    {
        private readonly DataBaseContextFactory _contextFactory;

        public PostRepository(DataBaseContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task CreateAsync(Domain.Entities.Post post)
        {
            using DataBaseContext context = _contextFactory.CreateDbContext();
            context.Posts.Add(post);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid postId)
        {
            using DataBaseContext context = _contextFactory.CreateDbContext();
            var post = await GetByIdAsync(postId);
            if (post is null) return;
            context.Remove(post);
            await context.SaveChangesAsync();
        }

        public Task<IEnumerable<Domain.Entities.Post>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Domain.Entities.Post>> GetByAuthorAsync(string author)
        {
            using DataBaseContext context = _contextFactory.CreateDbContext();
            var post = await context.Posts.AsNoTracking()
                                          .Where(i => i.Author == author)
                                          .Include(c => c.Comments)
                                          .AsNoTracking()
                                          .ToListAsync();
            return post;
        }

        public async ValueTask<Domain.Entities.Post?> GetByIdAsync(Guid postId)
        {
            using DataBaseContext context = _contextFactory.CreateDbContext();
            var post = await context.Posts.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == postId);
            return post;
        }

        public async Task<IEnumerable<Domain.Entities.Post>> GetWithCommentsAsync()
        {
            using DataBaseContext context = _contextFactory.CreateDbContext();
            var post = await context.Posts.AsNoTracking()
                                          .Where(i => i.Comments !=null && i.Comments.Any())
                                          .Include(c => c.Comments)
                                          .AsNoTracking()
                                          .ToListAsync();
            return post;
        }

        public async Task<IEnumerable<Domain.Entities.Post>> GetWithLikesAsync(int numberOfLikes)
        {
            using DataBaseContext context = _contextFactory.CreateDbContext();
            var post = await context.Posts.AsNoTracking()
                                          .Where(i => i.Likes ==numberOfLikes)
                                          .Include(c => c.Comments)
                                          .AsNoTracking()
                                          .ToListAsync();
            return post;
        }

        public async Task UpdateAsync(Domain.Entities.Post post)
        {
            using DataBaseContext context = _contextFactory.CreateDbContext();

            context.Posts.Update(post);
            await context.SaveChangesAsync();
        }
    }
}
