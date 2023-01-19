using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Post.Query.Domain.Entities;
using Post.Query.Domain.Repositories;
using Post.Query.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Query.Infrastructure.Repositories
{
    internal class CommentRepository : ICommentRepository
    {
        private readonly DataBaseContextFactory _contextFactory;

        public CommentRepository(DataBaseContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task CreateAsync(Comment comment)
        {
            using DataBaseContext context = _contextFactory.CreateDbContext();
            context.Comments.Add(comment);
           _= await context.SaveChangesAsync();

        }

        public async Task DeleteAsync(Guid commentId)
        {
            using DataBaseContext context = _contextFactory.CreateDbContext();
            var come = await GetByIdAsync(commentId);
            if (come is null) return;
            context.Remove(come);
            _=await context.SaveChangesAsync();
        }

        public async Task<Comment?> GetByIdAsync(Guid commentId)
        {
            using DataBaseContext context = _contextFactory.CreateDbContext();
            var comment= await context.Comments.FirstOrDefaultAsync(i => i.Id == commentId);
            return comment;
        }

        public async Task UpdateAsync(Comment comment)
        {
            using DataBaseContext context = _contextFactory.CreateDbContext();

            context.Comments.Update(comment);
            _=await context.SaveChangesAsync();
        }
    }
}
