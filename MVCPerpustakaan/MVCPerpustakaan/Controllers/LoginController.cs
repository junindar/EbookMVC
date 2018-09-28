using MVCPerpustakaan.ViewModels;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCPerpustakaan.Helpers;
using MVCPerpustakaan.Models;


namespace MVCPerpustakaan.Controllers
{
    public class LoginController : Controller
    {
        private PerpustakaanContext db = new PerpustakaanContext();
        // GET: Login
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return View();
        }

        [HttpPost]
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
                                DateTime.Now.AddYears(1), false, user.Role);
                            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                            HttpContext.Response.Cookies.Add(authCookie);
                            SessionManager.Set("Username", model.Username);
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

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var curUsername = SessionManager.Get<string>("Username");
                    var user = db.Users.FirstOrDefault(u =>
                    u.Username.ToLower().Equals(curUsername.ToLower()));
                    if (user != null)
                    {
                        if (user.Password == model.OldPassword)
                        {
                            user.Password = model.NewPassword;
                            db.SaveChanges();
                            ModelState.AddModelError("", "Password berhasil diganti.");

                        }
                        else
                        {
                            ModelState.AddModelError("", "Password lama salah.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username tidak dikenal.");
                    }
                }
              

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }


        [AllowAnonymous]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}