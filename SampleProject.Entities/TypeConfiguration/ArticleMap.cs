using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleProject.Core.TypeConfiguration.Abstract;
using SampleProject.Entities.Concrete;

namespace SampleProject.Entities.TypeConfiguration
{
    public class ArticleMap : BaseMap<Article>
    {
        public override void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasOne(a => a.AppUser).WithMany(a => a.Articles).HasForeignKey(a => a.AppUserID).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Category).WithMany(a => a.Articles).HasForeignKey(a => a.CategoryID).OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
