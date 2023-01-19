using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Post.Query.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using PostNamespace = Post.Query.Domain.Entities;
namespace Post.Query.Infrastructure.DataAccess.Mappings
{
    internal class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable($"{nameof(Comment)}s");
            builder.HasKey(p=>p.Id);
         
            builder.Property(p=>p.UserName).HasColumnType("varchar(50)").IsRequired();
            builder.Property(p=>p.CommentDate).HasColumnType("datetime").IsRequired();
            builder.Property(p=>p.Text).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(p=>p.Edited).HasColumnType("bit").IsRequired();


            //builder.HasOne(typeof(PostNamespace.Post))
            //       .WithMany()
            //     //  .HasForeignKey("PostId")
            //       .IsRequired(true);

        }
    }
}
