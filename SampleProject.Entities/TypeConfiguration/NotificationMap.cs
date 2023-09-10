using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleProject.Core.Entity.TypeConfiguration.Abstract;
using SampleProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Entities.TypeConfiguration
{
    public class NotificationMap : BaseMap<Notification>
    {
        public override void Configure(EntityTypeBuilder<Notification> builder)
        {
            base.Configure(builder);
        }
    }
}
