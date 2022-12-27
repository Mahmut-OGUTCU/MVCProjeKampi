using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> AdminGetList();

        void AdminAdd(Admin p);

        Admin AdminGetByID(int id);

        Admin AdminGetByMail(string p);

        Admin AdminGet(string username, string password);

        void AdminDelete(Admin p);

        void AdminUpdate(Admin p);
    }
}
