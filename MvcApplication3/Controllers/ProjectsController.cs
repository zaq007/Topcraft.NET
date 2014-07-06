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
    
    public class ProjectsController : Controller
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
        // GET: /Projects/
        ProjectRepository DB = new ProjectRepository();

        public ActionResult Index(int? Id)
        {
            if (Id == null) return View("Add");
            return View(DB.GetById((int)Id));
        }

        [Authorize]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult My()
        {
            
            return View(DB.GetUserProjects(CurrentUser));
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(Project p)
        {
            if (ModelState.IsValid)
            {
                p.OwnerID = CurrentUser.Id;
                p.Status = Statuses.Unconfirmed;
                p.TodayVotes = 0;
                p.Votes = 0;
                DB.Add(p);
                return View();
            }
            return View(p);
        }

        [Authorize]
        [HttpPost]
        public string Edit(int id, string name, string description, string url, string banner)
        {
            return DB.Update(id, name, description, url, banner, CurrentUser);
        }

        [Authorize]
        [HttpPost]
        public string Hide(int id)
        {
            return DB.Hide(id, CurrentUser);
        }

        [Authorize]
        [HttpPost]
        public string Transfer(int id, string new_owner)
        {
            return DB.Transfer(id, new_owner, CurrentUser);
        }

        [Authorize]
        [HttpPost]
        public string Delete(int id)
        {
            return DB.Delete(id, CurrentUser);
        }

        [Authorize]
        [HttpPost]
        public string NewUrl(int id, string url)
        {
            return DB.NewUrl(id, url, CurrentUser);
        }

        [Authorize]
        [HttpPost]
        public string NewApiHash(int id)
        {
            return DB.NewApiHash(id, CurrentUser);
        }

        public ActionResult GetView(Project p, int i)
        {
            ViewBag.i = i;
            return PartialView("Project", p);
        }

    }
}
