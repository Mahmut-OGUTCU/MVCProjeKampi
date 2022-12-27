using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDAL _messageDal;

        public MessageManager(IMessageDAL messageDal)
        {
            _messageDal = messageDal;
        }

        public void MessageAdd(Message p)
        {
            _messageDal.Insert(p);
        }

        public void MessageDelete(Message p)
        {
            throw new NotImplementedException();
        }

        public Message MessageGetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id && x.MessageisActive == true);
        }

        public List<Message> MessageGetList()
        {
            return _messageDal.List(x => x.MessageisActive == true);
        }

        public List<Message> MessageGetListInbox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.MessageisActive == true);
        }

        public List<Message> MessageGetListSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p && x.MessageisActive == true);
        }

        public void MessageUpdate(Message p)
        {
            _messageDal.Update(p);
        }
    }
}
