using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> HeadingGetList();

        List<Heading> HeadingGetListByWriter(int id);

        Heading HeadingGetById(int id);

        void HeadingUpdate(Heading p);

        void HeadingDelete(Heading p);

        void HeadingAdd(Heading p);
    }
}
