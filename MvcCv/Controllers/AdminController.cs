using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        GenericRepositorycs<TblAdmin> repo = new GenericRepositorycs<TblAdmin>();

        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }

        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminEkle(TblAdmin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult AdminSil(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            if (t != null)
            {
                repo.TDelete(t);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminDuzenle(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            if (t == null)
            {
                return RedirectToAction("Index");
            }
            return View(t);
        }

        [HttpPost]
        public ActionResult AdminGuncelle(TblAdmin p)
        {
            TblAdmin t = repo.Find(x => x.ID == p.ID);
            t.KullaniciAdi = p.KullaniciAdi;

            // Şifre alanı boş bırakılırsa eski şifre korunur
            if (!string.IsNullOrWhiteSpace(p.Sifre))
            {
                t.Sifre = p.Sifre;
            }

            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}