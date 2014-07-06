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
    public class ServersController : Controller
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

        ProjectRepository PR = new ProjectRepository();
        ServerRepository DB = new ServerRepository();
        //
        // GET: /Servers/
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Projects = PR.GetUserProjects(CurrentUser);
            ViewBag.Mods = DB.GetMods();
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(Mod[] b, Server s)
        {
            var a = PR.GetById(s.ProjectID).Owner == CurrentUser;
            if (ModelState.IsValid && a)
            {
                DB.Add(s);
            }
            return RedirectToAction("My", "Projects");
        }

    }
}
