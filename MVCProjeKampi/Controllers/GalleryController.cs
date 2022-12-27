using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager im = new ImageFileManager(new EFImageFileDAL());

        public ActionResult Index()
        {
            var galaryValues = im.ImageFileGetList();
            return View(galaryValues);
        }

        [HttpGet]
        public ActionResult GalleryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GalleryAdd(ImageFile p)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string type = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/AdminLTE-3.0.4/image/" + fileName + type;
                Request.Files[0].SaveAs(Server.MapPath(path));
                p.ImagePath = "/AdminLTE-3.0.4/image/" + fileName + type;
            }

            im.ImageFileAdd(p);
            return RedirectToAction("Index");
        }
    }
}