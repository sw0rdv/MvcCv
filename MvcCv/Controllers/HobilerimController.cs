using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HobilerimController : Controller
    {
        GenericRepositorycs<TblHobilerim> repo = new GenericRepositorycs<TblHobilerim>();

        [HttpGet]
        public ActionResult Index()
        {
            var hobi = repo.List().FirstOrDefault();
            return View(hobi);
        }

        [HttpPost]
        public ActionResult Index(TblHobilerim p)
        {
            var t = repo.Find(x => x.ID == p.ID);
            if (t != null)
            {
                t.Aciklama1 = p.Aciklama1;
                t.Aciklama2 = p.Aciklama2;
                repo.TUpdate(t);
            }
            return RedirectToAction("Index");
        }
    }
}