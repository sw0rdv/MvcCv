using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        GenericRepositorycs<TblHakkimda> repo = new GenericRepositorycs<TblHakkimda>();

        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List().FirstOrDefault(x => x.ID == 1);
            return View(hakkimda);
        }

        [HttpPost]
        public ActionResult Index(TblHakkimda p)
        {
            var t = repo.Find(x => x.ID == 1);
            if (t != null)
            {
                t.Ad = p.Ad;
                t.Soyad = p.Soyad;
                t.Adres = p.Adres;
                t.Telefon = p.Telefon;
                t.Mail = p.Mail;
                t.Aciklama = p.Aciklama;
                t.Resim = p.Resim;

                repo.TUpdate(t);
            }
            return RedirectToAction("Index");
        }
    }
}