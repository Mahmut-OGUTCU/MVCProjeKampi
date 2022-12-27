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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDAL _imagafileDal;

        public ImageFileManager(IImageFileDAL imagafileDal)
        {
            _imagafileDal = imagafileDal;
        }

        public void ImageFileAdd(ImageFile p)
        {
            _imagafileDal.Insert(p);
        }

        public List<ImageFile> ImageFileGetList()
        {
            return _imagafileDal.List();
        }
    }
}
