using Kaizen.Blog.DataAccess.EFCore.DbConfiguration;
using Kaizen.Blog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Blog.DataAccess.EFCore
{
    public class KaizenContext : DbContext
    {
        public KaizenContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Article> Articles{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<User> Users{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
