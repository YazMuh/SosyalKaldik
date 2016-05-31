using System.Linq;
using System.Web.Mvc;
using SosyalKaldık.Models;

namespace SosyalKaldık.Controllers
{

    public class AccountController : Controller
    {
       

        public AccountController()
        {
            
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