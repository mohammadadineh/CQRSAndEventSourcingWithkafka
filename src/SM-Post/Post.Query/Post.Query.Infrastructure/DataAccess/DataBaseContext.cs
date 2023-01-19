using Microsoft.EntityFrameworkCore;
using Post.Query.Domain.Entities;
using Post.Query.Infrastructure.DataAccess.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Query.Infrastructure.DataAccess
{
    internal sealed class DataBaseContext:DbContext
    {
        internal DataBaseContext(DbContextOptions options):base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CommentMapping());
            modelBuilder.ApplyConfiguration(new PostMapping());
        }

        public DbSet<Domain.Entities.Post> Posts { get;private set; }
        public DbSet<Comment> Comments{ get;private set; }
    }
}   
