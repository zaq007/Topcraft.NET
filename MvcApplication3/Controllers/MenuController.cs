using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.Global.Auth;
using MvcApplication3.Models;
using MvcApplication3.Models.Interfaces;
using Ninject;

namespace MvcApplication3.Controllers
{
    public class MenuController : Controller
    {
        [Inject]
        public IAuthentication Auth { get; set; }

        public Account CurrentUser
        {
            get
            {
                return ((IUserProvider)Auth.CurrentUser.Identity).User;
            }
        }
        //
        // GET: /Menu/
        public ActionResult Top()
        {
            ViewBag.CurrentUser = CurrentUser;
            return PartialView(CurrentUser==null?null:new Login());
        }

        public ActionResult Side()
        {
            ViewBag.CurrentUser = CurrentUser;
            return PartialView(CurrentUser == null ? null : new Login());
        }

        [HttpPost]
        public ActionResult Login(Login l)
        {
            if (ModelState.IsValid)
            {
                var user = Auth.Login(l.Email, l.Password);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState["Password"].Errors.Add("Пароли не совпадают");
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Logout()
        {
            Auth.LogOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
