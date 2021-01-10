using Kaizen.Blog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Blog.DataAccess.EFCore.DbConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .HasMaxLength(255)
                .IsRequired(true);

            builder.Property(u => u.Password)
                .HasMaxLength(25)
                .IsRequired(true);

            builder.HasMany(u => u.Articles)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

        }
    }
}
