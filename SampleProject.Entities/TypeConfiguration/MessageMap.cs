using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleProject.Core.Entity.TypeConfiguration.Abstract;
using SampleProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Entities.TypeConfiguration
{
    public class MessageMap : BaseMap<Message>
    {
        public override void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasOne(p=> p.SenderUser).WithMany(c=> c.Sender).HasForeignKey(a=> a.SenderID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p=> p.ReceiverUser).WithMany(c=> c.Receiver).HasForeignKey(a=> a.ReceiverID).OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
