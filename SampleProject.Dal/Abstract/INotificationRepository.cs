using SampleProject.Core.DataAccess.Abstract;
using SampleProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Dal.Abstract
{
    public interface INotificationRepository : IBaseRepository<Notification>
    {
    }
}
