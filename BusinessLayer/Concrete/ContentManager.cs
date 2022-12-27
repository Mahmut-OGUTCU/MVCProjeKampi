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
    public class ContentManager : IContentService
    {

        IContentDAL _contentDal;

        public ContentManager(IContentDAL contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAdd(Content p)
        {
            _contentDal.Insert(p);
        }

        public void ContentDelete(Content p)
        {
            throw new NotImplementedException();
        }

        public Content ContentGetById(int id)
        {
            return _contentDal.Get(x => x.ContentID == id && x.ContentisActive == true);
        }

        public List<Content> ContentGetList(string p)
        {
            return _contentDal.List(x => x.ContentValue.Contains(p) && x.ContentisActive == true);
        }

        public List<Content> ContentGetListByHeading(int id)
        {
            return _contentDal.List(x => x.HeadingID == id && x.ContentisActive == true);
        }

        public List<Content> ContentGetListByWriter(int id)
        {
            return _contentDal.List(x => x.WriterID == id && x.ContentisActive == true);
        }

        public void ContentUpdate(Content p)
        {
            _contentDal.Update(p);
        }
    }
}
