using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;
namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepositorycs<TblSertifikalarım> repo = new GenericRepositorycs<TblSertifikalarım>();
        public ActionResult Index()
        {
            var sertifikalar = repo.List();
            return View(sertifikalar);
        }

        public ActionResult SertifikaSil(int id)
        {
            TblSertifikalarım t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            TblSertifikalarım t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifikalarım t)
        {
            TblSertifikalarım t1 = repo.Find(x => x.ID == t.ID);
            t1.Aciklama = t.Aciklama;
            t1.Tarih = t.Tarih;
            repo.TUpdate(t1);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SertifikaAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaAdd(TblSertifikalarım t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }
    }
}