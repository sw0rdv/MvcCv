using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{

    public class EgitimController : Controller
    {
        GenericRepositorycs<TblEgitim> repo = new GenericRepositorycs<TblEgitim>();

        // GET: Egitim
        public ActionResult Index()
        {
            var egitimler = repo.List(); // Generic Repository'deki listeleme metodunuz (List() veya GetAll())
            return View(egitimler);
        }
        [HttpGet]
        public ActionResult EgitimAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimAdd(TblEgitim p)
        {
            if(!ModelState.IsValid)
            {
                return View("EgitimAdd");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View("EgitimGetir", egitim);
        }
        [HttpPost]
        public ActionResult EgitimGetir(TblEgitim p)
        {
            if(!ModelState.IsValid)
            {
                return View("EgitimGetir");
            }
            var egitim = repo.Find(x => x.ID == p.ID);
            egitim.Baslik = p.Baslik;
            egitim.AltBaslik1 = p.AltBaslik1;
            egitim.AltBaslik2 = p.AltBaslik2;
            egitim.GNO = p.GNO;
            egitim.Tarih = p.Tarih;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }
    }
}