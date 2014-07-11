using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.Global.Auth;
using MvcApplication3.Models;
using MvcApplication3.Models.Boundary;
using Ninject;

namespace MvcApplication3.Controllers
{
    public class AdController : Controller
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

        AdRepository AR = new AdRepository();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public string Add(Ad ad, int Value)
        {
            if (ModelState.IsValid && Value > 0)
            {
                return AR.Add(ad, Value, CurrentUser);
            }
            else
                return "Пожалуйста, заполните верно поля";

        }

    }
}
