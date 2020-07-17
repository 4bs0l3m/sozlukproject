using SozlukSitesi.Core.İnfastructure;
using SozlukSitesi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SozlukSitesi.Admin.Controllers
{
    public class AccountController : Controller
    {
        #region Kullanici
        private readonly IKullaniciRepository _kullaniciRepository;
        #endregion
        #region Rol
        private readonly IRolRepository _rolRepository;
        public AccountController(IKullaniciRepository kullaniciRepository, IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
            _kullaniciRepository = kullaniciRepository;
        }
        #endregion
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {

            if (isLogin())
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(Kullanici kullanici)
        {
            var KullaniciVarMi = _kullaniciRepository.GetMany(
                x => x.KullaniciAdi == kullanici.KullaniciAdi
                && x.Sifre == kullanici.Sifre).SingleOrDefault();
            if (KullaniciVarMi != null)
            {
                //if (KullaniciVarMi.Rol.RolAdi == "Admin")
                //{
                //    Session["kullaniciID"] = KullaniciVarMi.ID;
                //    return RedirectToAction("Index", "Home");
                //}
                Session["kullaniciID"] = KullaniciVarMi.ID;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Mesaj = "Yetkisiz Kullanıcı!";
            return View();
        }
        public bool isLogin()
        {
            if (Session["kullaniciID"] != null)
                return true;
            else
                return false;

        }
        [HttpGet]
        public ActionResult KayitOl()
        {
            if (isLogin())
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(Kullanici kullanici)
        {
            kullanici.Aktif = false;
            kullanici.KayitTarihi = DateTime.Now;
            kullanici.eMail_Onay = false;
            kullanici.Rol = _rolRepository.GetById(4);
            _kullaniciRepository.Insert(kullanici);
            _kullaniciRepository.Save();
            return RedirectToAction("Login", "Account");
        }
        public bool CikisYap()
        {
            Kullanici kullanici = _kullaniciRepository.GetById(Convert.ToInt32(Session["kullaniciID"]));
            kullanici.Aktif = false;
            _kullaniciRepository.Update(kullanici);
            _kullaniciRepository.Save();
            Session["kullaniciID"] = null;
            return true;
        }
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
    }
}