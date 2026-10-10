using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;
namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya

        GenericRepositorycs<TblSosyalMedya> repo = new GenericRepositorycs<TblSosyalMedya>();
        DbCvEntities2 db = new DbCvEntities2();
        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult SosyalMedyaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SosyalMedyaEkle(TblSosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult SosyalMedyaSil(int id)
        {
            var sosyalmedya = repo.Find(x => x.ID == id);
            sosyalmedya.Durum = false;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SosyalMedyaGetir(int id)
        {
            var sosyalmedya = repo.Find(x => x.ID == id);
            return View(sosyalmedya);
        }
        [HttpPost]
        public ActionResult SosyalMedyaGetir(TblSosyalMedya p)
        {
            var sosyalmedya = repo.Find(x => x.ID == p.ID);
            sosyalmedya.Ad = p.Ad;
            sosyalmedya.Durum = true;
            sosyalmedya.Link = p.Link;
            sosyalmedya.ikon = p.ikon;
            repo.TUpdate(sosyalmedya);
            return RedirectToAction("Index");
        }
    }
}