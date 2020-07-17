using SozlukSitesi.Admin.CustomFilter;
using SozlukSitesi.Core.İnfastructure;
using SozlukSitesi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SozlukSitesi.Admin.Controllers
{
    public class HomeController : Controller
    {
        #region Kullanici
        private readonly IKullaniciRepository _kullaniciRepository;
        private readonly IEntryRepository _entryRepository;
        private readonly IBaslikRepository _baslikRepository;
        public HomeController(IKullaniciRepository kullaniciRepository,
            IEntryRepository entriRepository,
            IBaslikRepository baslikRepository)
        {
            _kullaniciRepository = kullaniciRepository;
            _entryRepository = entriRepository;
            _baslikRepository = baslikRepository;
        }
        #endregion
        // GET: Home
 //       [LoginFilter]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [LoginFilter]
        public ActionResult kullaniciList()
        {
            return View();
        }
        [HttpGet]
        public JsonResult kullanicilarJson()
        {
            //if (Session["kullaniciID"] != null)
            //{
            //    if (_kullaniciRepository.GetById(Convert.ToInt32(Session["kullaniciID"])).Rol.RolAdi == "Admin")
            //    {
            //        return Json(_kullaniciRepository.GetAll(), JsonRequestBehavior.AllowGet);
            //    }
            //    else
            //    {
            //        return Json(null, JsonRequestBehavior.AllowGet);
            //    }
            //}
            //else
            //{
            //    return Json(null, JsonRequestBehavior.AllowGet);
            //}
            var result = _kullaniciRepository.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [LoginFilter]
        public ActionResult baslikOlustur()
        {
            return View();
        }
        [HttpPost]
        public ActionResult baslikOlustur(Baslik baslik)
        {
            baslik.YayinTarihi = DateTime.Now;
            baslik.Hate = 0;
            baslik.Like = 0;
            baslik.Yayınlayan = _kullaniciRepository.GetById(Convert.ToInt32(Session["kullaniciID"]));
            _baslikRepository.Insert(baslik);
            _baslikRepository.Save();
            return View();
        }
        [HttpGet]
        public ActionResult entry(int id)
        {
            ViewBag.baslikAdi = _baslikRepository.GetById(id).Ad;
            return View();
        }
        [HttpPost]
        public ActionResult entry(int id, Entry entry)
        {
            entry.Baslik = _baslikRepository.GetById(id);
            entry.girisTarihi = DateTime.Now;
            entry.Hate = 0;
            entry.Like = 0;
            entry.kisaMetin = entry.Metin;
            entry.eSahibi = _kullaniciRepository.GetById(Convert.ToInt32(Session["kullaniciID"]));
            _entryRepository.Insert(entry);
            _entryRepository.Save();
            return View();
        }
        [HttpGet]
        public JsonResult entrylerJson(int id)
        {
            var result = _entryRepository.GetMany(x=>x.Baslik.ID==id);
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult basliklar()
        {
            ViewBag.Basliklar = _baslikRepository.GetAll();
            return View();
        }
        public JsonResult basliklarJson()
        {
            var result = _baslikRepository.GetAll();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}