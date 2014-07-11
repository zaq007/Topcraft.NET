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
    [Authorize(Roles="Member,Admin")]
    public class ServiceController : Controller
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

        AdRepository AS = new AdRepository();
        ProjectRepository PR = new ProjectRepository();

        public ActionResult Index()
        {
            ViewBag.Ads = AS.GetByOwner(CurrentUser);
            ViewBag.Projects = PR.GetUserProjects(CurrentUser);
            ViewBag.Prices = AS.GetPrices();
            return View();
        }

    }
}
