using SampleProject.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Entities.Concrete
{
    public class Message : BaseEntity
    {
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public AppUser SenderUser { get; set; }
        public AppUser ReceiverUser { get; set; }
    }
}
