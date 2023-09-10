using Microsoft.EntityFrameworkCore;
using SampleProject.Core.DataAccess.Concrete;
using SampleProject.Dal.Abstract;
using SampleProject.Dal.Context;
using SampleProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleProject.Dal.Concrete.EfRepository
{
    public class EfMessageRepository : EfBaseRepository<Message,ProjectContext>, IMessageRepository
    {
        private readonly ProjectContext _context;
        public EfMessageRepository(ProjectContext context) : base(context)
        {
            _context=context;
        }

        public List<Message> GetListWithSender(int id)
        {
            return _context.Messages.Include(p=> p.SenderUser).Where(p=> p.ReceiverID==id).ToList();
        }
    }
}
