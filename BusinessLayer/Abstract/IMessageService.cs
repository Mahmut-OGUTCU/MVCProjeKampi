using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> MessageGetListInbox(string p);

        List<Message> MessageGetListSendbox(string p);

        List<Message> MessageGetList();

        void MessageAdd(Message p);

        Message MessageGetByID(int id);

        void MessageDelete(Message p);

        void MessageUpdate(Message p);
    }
}
