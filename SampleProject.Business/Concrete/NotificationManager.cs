using Microsoft.EntityFrameworkCore.Query;
using SampleProject.Business.Abstract;
using SampleProject.Dal.Abstract;
using SampleProject.Dal.Concrete.EfRepository;
using SampleProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SampleProject.Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationManager(INotificationRepository notificationRepository)
        {
            _notificationRepository=notificationRepository;
        }
        public bool Any(Expression<Func<Notification, bool>> expression)
        {
            return _notificationRepository.Any(expression);
        }

        public void Create(Notification entity)
        {
            _notificationRepository.Create(entity);
        }

        public void Delete(Notification entity)
        {
            _notificationRepository.Delete(entity);
        }

        public TResult GetByDefault<TResult>(Expression<Func<Notification, TResult>> selector, Expression<Func<Notification, bool>> expression, Func<IQueryable<Notification>, IIncludableQueryable<Notification, object>> include = null)
        {
            return _notificationRepository.GetByDefault(selector, expression, include);
        }

        public List<TResult> GetByDefaults<TResult>(Expression<Func<Notification, TResult>> selector, Expression<Func<Notification, bool>> expression, Func<IQueryable<Notification>, IIncludableQueryable<Notification, object>> include = null, Func<IQueryable<Notification>, IOrderedQueryable<Notification>> orderBy = null)
        {
            return _notificationRepository.GetByDefaults(selector, expression, include, orderBy);
        }

        public Notification GetDefault(Expression<Func<Notification, bool>> expression)
        {
            return _notificationRepository.GetDefault(expression);
        }

        public List<Notification> GetDefaults(Expression<Func<Notification, bool>> expression)
        {
            return _notificationRepository.GetDefaults(expression);
        }

        public void Update(Notification entity)
        {
            _notificationRepository.Update(entity);
        }
    }
}
