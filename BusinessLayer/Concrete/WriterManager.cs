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
    public class WriterManager : IWriterService
    {
        IWriterDAL _writerDal;

        public WriterManager(IWriterDAL writerDal)
        {
            _writerDal = writerDal;
        }

        public void WriterAdd(Writer p)
        {
            _writerDal.Insert(p);
        }

        public void WriterDelete(Writer p)
        {
            _writerDal.Delete(p);
        }

        public Writer WriterGetById(int id)
        {
            return _writerDal.Get(x => x.WriterID == id && x.WriterisActive == true);
        }

        public Writer WriterGetByMail(string mail)
        {
            return _writerDal.Get(x => x.WriterMail == mail && x.WriterisActive == true);
        }

        public List<Writer> WriterGetList()
        {
            return _writerDal.List(x => x.WriterisActive == true);
        }

        public void WriterUpdate(Writer p)
        {
            _writerDal.Update(p);
        }
    }
}
