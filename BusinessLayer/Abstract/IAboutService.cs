using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public interface IAboutService
    {
        List<About> AboutGetList();

        About AboutGetById(int id);

        void AboutUpdate(About p);

        void AboutDelete(About p);

        void AboutAdd(About p);
    }
}
