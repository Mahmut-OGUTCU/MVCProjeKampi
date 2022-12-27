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
    public class HeadingManager : IHeadingService
    {
        IHeadingDAL _headingDal;

        public HeadingManager(IHeadingDAL headingDal)
        {
            _headingDal = headingDal;
        }

        public void HeadingAdd(Heading p)
        {
            _headingDal.Insert(p);
        }

        public void HeadingDelete(Heading p)
        {
            _headingDal.Update(p);
        }

        public Heading HeadingGetById(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id && x.HeadingisActive == true);
        }

        public List<Heading> HeadingGetList()
        {
            return _headingDal.List(x => x.HeadingisActive == true);
        }

        public List<Heading> HeadingGetListByWriter(int id)
        {
            return _headingDal.List(x => x.WriterID == id && x.HeadingisActive == true);
        }

        public void HeadingUpdate(Heading p)
        {
            _headingDal.Update(p);
        }
    }
}
