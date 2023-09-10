using Microsoft.EntityFrameworkCore;
using SampleProject.Core.DataAccess.Concrete;
using SampleProject.Dal.Abstract;
using SampleProject.Dal.Context;
using SampleProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Dal.Concrete.EfRepository
{
    public class EfNotificationRepository : EfBaseRepository<Notification, ProjectContext>, INotificationRepository
    {
        public EfNotificationRepository(ProjectContext context) : base(context)
        {
        }
    }
}
