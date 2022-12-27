using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDAL _aboutDal;

        public AboutManager(IAboutDAL aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void AboutAdd(About p)
        {
            _aboutDal.Insert(p);
        }

        public void AboutDelete(About p)
        {
            _aboutDal.Delete(p);
        }

        public About AboutGetById(int id)
        {
            return _aboutDal.Get(x => x.AboutID == id && x.AboutisActive == true);
        }

        public List<About> AboutGetList()
        {
            return _aboutDal.List(x => x.AboutisActive == true);
        }

        public void AboutUpdate(About p)
        {
            _aboutDal.Update(p);
        }
    }
}
