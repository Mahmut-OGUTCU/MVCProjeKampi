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
    public class ContactManager : IContactService
    {
        IContactDAL _contactDal;

        public ContactManager(IContactDAL contactDal)
        {
            _contactDal = contactDal;
        }

        public void ContactAdd(Contact p)
        {
            _contactDal.Insert(p);
        }

        public void ContactDelete(Contact p)
        {
            _contactDal.Delete(p);
        }

        public Contact ContactGetByID(int id)
        {
            return _contactDal.Get(x => x.ContactID == id && x.ContactisActive == true);
        }

        public List<Contact> ContactGetList()
        {
            return _contactDal.List(x => x.ContactisActive == true);
        }

        public void ContactUpdate(Contact p)
        {
            _contactDal.Update(p);
        }
    }
}
