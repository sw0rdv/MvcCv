using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]    
    public class DefaultController : Controller
    {
        // GET: Default

        DbCvEntities2 db = new DbCvEntities2();
        public ActionResult Index()
        {
            var values = db.TblHakkimda.ToList();
            return View(values);
        }
        public PartialViewResult SosyalMedya()
        {
            var values = db.TblSosyalMedya.Where(x => x.Durum == true).ToList();
            return PartialView(values);

        }

        public PartialViewResult Deneyim()
        {
            var values = db.TblDeneyimler.ToList();
            return PartialView(values);

        }
        public PartialViewResult Egitim()
        {
            var values = db.TblEgitim.ToList();
            return PartialView(values);
        }
        public PartialViewResult Yeteneklerim()
        {
            var values = db.TblYetenekler.ToList();
            return PartialView(values);
        }

        public PartialViewResult Hobilerim()
        {
            var values = db.TblHobilerim.ToList();
            return PartialView(values);
        }
        public PartialViewResult Sertifikalarim()
        {
            var values = db.TblSertifikalarım.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletisim(Tbliletisim t)
        {
            t.Tarih = DateTime.Now;

            db.Tbliletisim.Add(t);
            db.SaveChanges();

            return PartialView();
        }
    }
}