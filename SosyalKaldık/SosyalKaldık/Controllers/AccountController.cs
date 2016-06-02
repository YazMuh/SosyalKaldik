using System.Linq;
using System.Web.Mvc;
using SosyalKaldık.Models;
using System.Collections.Generic;
using System;

namespace SosyalKaldık.Controllers
{

    public class AccountController : Controller
    {
       

        public AccountController()
        {
            
        }

        [HttpPost]
        public ActionResult EtkinlikEkle(EtkinlikModel model)
        {
            
            SosyalKalEntities1 contex = new SosyalKalEntities1();
            ETKINLIK etk = new ETKINLIK();
            etk.ETK_ACIKLAMA = model.ETK_ACIKLAMA;
            etk.ETK_BASLIK = model.ETK_BASLIK;
            etk.ETK_ILCE = model.ETK_ILCE;
            etk.ETK_SEHIR = model.ETK_SEHIR;
            etk.KAT_ID = model.KAT_ID;
            etk.ETK_TARIH_SAAT = 
             Convert.ToDateTime(model.ETK_TARIH_SAAT);
            etk.KUL_ID = ((KULLANICI)(Session["Uye"])).KUL_ID;
            contex.ETKINLIKs.Add(etk);
            contex.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        public ActionResult EtkinlikEkle()
        {

            EtkinlikModel model = new EtkinlikModel();
            SosyalKalEntities1 contex = new SosyalKalEntities1();
            List<KATEGORI> kategoriler = contex.KATEGORIs.ToList();
            model.Kategoriler = (from j in kategoriler
                              select new SelectListItem
                              {
                                  Text = j.KAT_ADI,
                                  Value = j.KAT_ID.ToString()
                              }).ToList();
            model.Kategoriler.Insert(0, new SelectListItem { Text = "Seçiniz", Value = "" });
            return View(model);
        }

        public ActionResult EtkinlikGoruntule()
        {
            KULLANICI a = ((KULLANICI)(Session["Uye"]));
            SosyalKalEntities1 contex = new SosyalKalEntities1();
            EtkinlikModel model = new EtkinlikModel();
            model.Tel = a.KUL_TELEFON;
            List<ETKINLIK> list = contex.ETKINLIKs.Where(c => c.KUL_ID == a.KUL_ID).ToList();
            model.etkinlikList = list;
            return View(model);
        }
        public ActionResult EtkinlikSil(int id)
        {

            SosyalKalEntities1 contex = new SosyalKalEntities1();
            int a = ((KULLANICI)Session["Uye"]).KUL_ID;
            var duzenle = contex.ETKINLIKs.Where(c => c.ETK_ID == id).ToList().FirstOrDefault();
            contex.ETKINLIKs.Remove(duzenle);
            contex.SaveChanges();


            return RedirectToAction("EtkinlikGoruntule");
        }


        //
        // GET: /Account/Login

        public ActionResult Login()
        {
           // ViewBag.ReturnUrl = returnUrl;
            return View();
        }
      
        //
        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            SosyalKalEntities1 contex = new SosyalKalEntities1();

            var mems = from c in contex.KULLANICIs
                       where c.KUL_EMAIL == model.Email && c.KUL_PASSWORD == model.Password
                       select c;

            if (mems.ToList().Count == 1)
            {
                KULLANICI m = mems.ToList().FirstOrDefault();
                Session["Uye"] = m;

                return RedirectToAction("Index", "Home");
            }



            return View();
        }


       

        //
        // GET: /Account/Register
        
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult  Register(RegisterViewModel model)
        {
            SosyalKalEntities1 a = new SosyalKalEntities1();
            KULLANICI b = new KULLANICI();

            b.KUL_EMAIL = model.Email;
            b.KUL_PASSWORD = model.Password;
            b.KUL_TELEFON = model.Tel;
            b.KUL_ADI = model.Adı;
            b.KUL_SOYADI = model.Soyadı;


            a.KULLANICIs.Add(b);

          
            if (a.SaveChanges() >=1)
            {
                Session["Uye"] = b;
                return RedirectToAction("Index", "Home");
            }
           

          
            return View(model);
        }

        
        
        public ActionResult LogOut()
        {
            Session["Uye"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Edit()
        {
            SosyalKalEntities1 contex = new SosyalKalEntities1();
            EditViewModel model = new EditViewModel();
            KULLANICI kul = ((KULLANICI)(Session["Uye"]));
            model.Adı = kul.KUL_ADI;
            model.Tel = kul.KUL_TELEFON;
            model.Email = kul.KUL_EMAIL;
            model.Soyadı = kul.KUL_SOYADI;
           
            
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditViewModel model)
        {
            SosyalKalEntities1 contex = new SosyalKalEntities1();

            KULLANICI temp = (KULLANICI)(Session["Uye"]);


            var duzenle = contex.KULLANICIs.Where(c => c.KUL_ID == temp.KUL_ID && c.KUL_PASSWORD == temp.KUL_PASSWORD).ToList().First();
            
            duzenle.KUL_ADI = model.Adı;
            duzenle.KUL_SOYADI = model.Soyadı;
            duzenle.KUL_TELEFON = model.Tel;
            
            contex.SaveChanges();
            Session["Uye"] = duzenle;
            ViewData["Status"] = "Update Sucessful!";
            return RedirectToAction("Index", "Home");
        }

    }
}