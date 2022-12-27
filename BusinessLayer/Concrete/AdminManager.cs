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
    public class AdminManager : IAdminService
    {
        IAdminDAL _adminDal;

        public AdminManager(IAdminDAL adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAdd(Admin p)
        {
            _adminDal.Insert(p);
        }

        public void AdminDelete(Admin p)
        {
            throw new NotImplementedException();
        }

        public Admin AdminGet(string username, string password)
        {
            return _adminDal.Get(x => x.AdminUserName == username && x.AdminPassword == password && x.AdminisActive == true);
        }

        public Admin AdminGetByID(int id)
        {
            return _adminDal.Get(x => x.AdminID == id && x.AdminisActive == true);
        }

        public Admin AdminGetByMail(string p)
        {
            return _adminDal.Get(x => x.AdminUserName == p && x.AdminisActive == true);
        }

        public List<Admin> AdminGetList()
        {
            return _adminDal.List(x => x.AdminisActive == true);
        }

        public void AdminUpdate(Admin p)
        {
            _adminDal.Update(p);
        }
    }
}
