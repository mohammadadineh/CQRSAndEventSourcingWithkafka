using Microsoft.EntityFrameworkCore;
using Post.Query.Infrastructure.DataAccess.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Query.Infrastructure.DataAccess
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions options):base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CommentMapping());
            modelBuilder.ApplyConfiguration(new PostMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}   
