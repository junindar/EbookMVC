using MVCPerpustakaan.ViewModels;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCPerpustakaan.Models;

namespace MVCPerpustakaan.Controllers
{
    public class LoginController : Controller
    {
        private PerpustakaanContext db = new PerpustakaanContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = db.Users.Find(model.Username);
                    if (user != null)
                    {
                        if (user.Password == model.Password)
                        {
                            FormsAuthentication.SetAuthCookie(model.Username, false);
                            var authTicket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now, 
                                DateTime.Now.AddMinutes(20), false, user.Role);
                            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                            HttpContext.Response.Cookies.Add(authCookie);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Password salah!");
                            return View(model);
                        }
                       
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username salah!");
                        return View(model);
                    }

                }
               
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}