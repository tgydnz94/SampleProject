using SampleProject.Core.Business;
using SampleProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Business.Abstract
{
    public interface IMessageService : IGenericBus<Message>
    {
        List<Message> GetMessages(int id);
        List<Message> GetListMessages(int id);
    }
}
