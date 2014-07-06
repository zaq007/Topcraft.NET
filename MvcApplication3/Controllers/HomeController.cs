using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.Models;
using MvcApplication3.Models.Boundary;

namespace MvcApplication3.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        ProjectRepository Projects = new ProjectRepository();
        public ActionResult Index()
        {
            return View(Projects.GetProjectsForMainPage());
        }
    }
}
