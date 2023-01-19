using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Post.Query.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PostNamespace = Post.Query.Domain.Entities;
namespace Post.Query.Infrastructure.DataAccess.Mappings
{
    internal class PostMapping : IEntityTypeConfiguration<PostNamespace.Post>
    {
        public void Configure(EntityTypeBuilder<PostNamespace.Post> builder)
        {
            builder.ToTable($"{nameof(PostNamespace.Post)}s");
            builder.HasKey(p=>p.Id);
            builder.Property(p=>p.Author).HasColumnType("varchar(50)").IsRequired();
            builder.Property(p=>p.DatePosted).HasColumnType("datetime").IsRequired();
            builder.Property(p=>p.Message).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(p=>p.Likes).HasColumnType("int").IsRequired();


        }
    }
}
