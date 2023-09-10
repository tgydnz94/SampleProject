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
    public class MessageManager : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageManager(IMessageRepository messageRepository)
        {
            _messageRepository=messageRepository;
        }
        public bool Any(Expression<Func<Message, bool>> expression)
        {
            return _messageRepository.Any(expression);
        }

        public void Create(Message entity)
        {
            _messageRepository.Create(entity);
        }

        public void Delete(Message entity)
        {
            _messageRepository.Delete(entity);
        }

        public TResult GetByDefault<TResult>(Expression<Func<Message, TResult>> selector, Expression<Func<Message, bool>> expression, Func<IQueryable<Message>, IIncludableQueryable<Message, object>> include = null)
        {
            return _messageRepository.GetByDefault(selector, expression, include);
        }

        public List<TResult> GetByDefaults<TResult>(Expression<Func<Message, TResult>> selector, Expression<Func<Message, bool>> expression, Func<IQueryable<Message>, IIncludableQueryable<Message, object>> include = null, Func<IQueryable<Message>, IOrderedQueryable<Message>> orderBy = null)
        {
            return _messageRepository.GetByDefaults(selector, expression, include, orderBy);
        }

        public Message GetDefault(Expression<Func<Message, bool>> expression)
        {
            return _messageRepository.GetDefault(expression);
        }

        public List<Message> GetDefaults(Expression<Func<Message, bool>> expression)
        {
            return _messageRepository.GetDefaults(expression);
        }

        public List<Message> GetListMessages(int id)
        {
            return _messageRepository.GetListWithSender(id);
        }

        public List<Message> GetMessages(int id)
        {
            return _messageRepository.GetDefaults(p => p.ReceiverID == id);
        }

        public void Update(Message entity)
        {
            _messageRepository.Update(entity);
        }
    }
}
