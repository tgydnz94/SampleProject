using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SampleProject.Core.Entity.TypeConfiguration.Concrete;
using SampleProject.Entities.Concrete;
using SampleProject.Entities.TypeConfiguration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Dal.Context
{
    public class ProjectContext : IdentityDbContext
    {
        public ProjectContext(DbContextOptions options) : base(options) { }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserFollowedCategories> UserFollowedCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppUserMap());
            builder.ApplyConfiguration(new ArticleMap());
            builder.ApplyConfiguration(new CommentMap());
            builder.ApplyConfiguration(new IdentityRoleMap());
            builder.ApplyConfiguration(new LikeMap());
            builder.ApplyConfiguration(new UserFollowedCategoryMap());

            base.OnModelCreating(builder);
        }
    }
}
