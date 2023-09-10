using SampleProject.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Entities.Concrete
{
    public class Notification : BaseEntity
    {
        public string NotificationType { get; set; }
        public string NotificationTypeSymbol { get; set; }
        public string NotificationDetails { get; set; }

    }
}
