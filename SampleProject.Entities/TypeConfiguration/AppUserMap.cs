using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleProject.Core.TypeConfiguration.Abstract;
using SampleProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Entities.TypeConfiguration
{
    public class AppUserMap : BaseMap<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(a => a.FirstName).HasMaxLength(50).IsRequired(true);

            base.Configure(builder);
        }
    }
}
