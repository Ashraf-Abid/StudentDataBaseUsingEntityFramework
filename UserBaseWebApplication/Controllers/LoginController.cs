using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserBaseWebApplication.Models;

namespace UserBaseWebApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        UsersBaseAppEntities dbobj = new UsersBaseAppEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User objx)
        {
          
            if (ModelState.IsValid)
            {
                using (UsersBaseAppEntities dbobj = new UsersBaseAppEntities())
                {
                    var obj = dbobj.Users.Where(x => x.username.Equals(objx.username) && x.password.Equals(objx.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.id.ToString();
                        Session["UserName"] = obj.username.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else {
                        ModelState.AddModelError("", "The UserName or password incorrect");
                    }
                }
                
            }
            return View(objx);
        }
        public ActionResult Logout() {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}