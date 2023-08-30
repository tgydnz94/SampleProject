using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleProject.Entities.Concrete;

namespace SampleProject.Entities.TypeConfiguration
{
    public class UserFollowedCategoryMap : IEntityTypeConfiguration<UserFollowedCategories>
    {
        public void Configure(EntityTypeBuilder<UserFollowedCategories> builder)
        {
            builder.HasKey(a => new { a.AppUserID, a.CategoryID });

            builder.HasOne(a => a.AppUser).WithMany(a => a.UserFollowedCategories).HasForeignKey(a => a.AppUserID);

            builder.HasOne(a => a.Category).WithMany(a => a.UserFollowedCategories).HasForeignKey(a => a.CategoryID);
        }
    }
}
