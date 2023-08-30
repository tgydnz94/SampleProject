using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleProject.Core.Entity.TypeConfiguration.Abstract;
using SampleProject.Entities.Concrete;

namespace SampleProject.Entities.TypeConfiguration
{
    public class CommentMap : BaseMap<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(a => a.AppUser).WithMany(a => a.Comments).HasForeignKey(a => a.AppUserID).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Article).WithMany(a => a.Comments).HasForeignKey(a => a.ArticleID).OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
