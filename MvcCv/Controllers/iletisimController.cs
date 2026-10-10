using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class iletisimController : Controller
    {
        // Generic Repository veya DbCvEntities üzerinden iletişim tablosunu çekiyoruz
        GenericRepositorycs<Tbliletisim> repo = new GenericRepositorycs<Tbliletisim>();

        // GET: iletisim
        public ActionResult Index()
        {
            var iletisimListesi = repo.List().OrderByDescending(x => x.Tarih).ToList(); ;
            return View(iletisimListesi); // Modeli View'e parametre olarak geçiyoruz
        }

        public ActionResult MesajSil(int id)
        {
            Tbliletisim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
    }
}