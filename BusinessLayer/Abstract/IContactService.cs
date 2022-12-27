using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> ContactGetList();

        void ContactAdd(Contact p);

        Contact ContactGetByID(int id);

        void ContactDelete(Contact p);

        void ContactUpdate(Contact p);
    }
}
