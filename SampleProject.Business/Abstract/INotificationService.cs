using SampleProject.Core.Business;
using SampleProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Business.Abstract
{
    public interface INotificationService : IGenericBus<Notification>
    {
    }
}
