using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCNorthwind.Models;

namespace MVCNorthwind.Controllers
{
    public class KategoriController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        // GET: Kategori
        public ActionResult Index()
        {

            return View(db.Categories.ToList());
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Categories c)
        {
            try
            {
                if (!string.IsNullOrEmpty(c.CategoryName))
                {
                    db.Categories.Add(c);
                    db.SaveChanges();
                    ViewBag.basarili = "Başarılı";
                }
                else
                {
                    ViewBag.basarisiz = "Kategori adı boş bırakılamaz";
                }
            }
            catch
            {
                ViewBag.basarisiz = "Ekleme işlemi başarısız";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Duzenle(int? id)
        {
            Categories c = db.Categories.Find(id);
            if (id != null)
            {
                if (c != null)
                {
                    return View(c);
                }
                else
                {
                    return RedirectToAction("Index", "Kategori");
                }
            }
            else
            {
                return RedirectToAction("Index", "Kategori");

            }
        }
    }
}