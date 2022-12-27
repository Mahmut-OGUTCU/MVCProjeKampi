using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> ContentGetList(string p);

        List<Content> ContentGetListByWriter(int id);

        List<Content> ContentGetListByHeading(int id);

        Content ContentGetById(int id);

        void ContentAdd(Content p);

        void ContentUpdate(Content p);

        void ContentDelete(Content p);
    }
}
