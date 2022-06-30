using PortalDeloitte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace PortalDeloitte.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.Interns model)
        {
            using (var context = new CASESTUDYEntities())
            {
                bool isValid = context.UserInfoes.Any(x => x.Username == model.Username && x.Password == model.Password);
                if(isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("Index","UserInfoes");
                }

                ModelState.AddModelError("", "Invalid username and password");
                return View();
            }
        }


        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Models.UserInfo model)
        {
            using (var context = new CASESTUDYEntities())
            {
                context.UserInfoes.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }
    }
}