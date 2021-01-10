using Kaizen.Blog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Blog.DataAccess.EFCore.DbConfiguration
{
    public class ArticleConfiguration:IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Title)
                .HasMaxLength(255)
                .IsRequired(true);


            builder.HasOne(a => a.User)
                .WithMany(u => u.Articles)
                .HasForeignKey(a => a.UserId);

            builder.HasOne(a => a.Category)
                .WithMany(u => u.Articles)
                .HasForeignKey(a => a.CategoryId);

        }
    }
}
