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

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        AccountRespository AccountsDB = new AccountRespository();
        ProjectRepository ProjectsDB = new ProjectRepository();

        public ActionResult Index()
        {
            return View();
        }

        #region Accounts

        public ActionResult Accounts()
        {
            
            return View(AccountsDB.Accounts.ToList());
        }

        [HttpGet]
        public ActionResult EditAccount(int id)
        {
            Account account = AccountsDB.GetById(id);
            return View(account);
        }

        [HttpPost]
        public ActionResult EditAccount(Account account)
        {
            AccountsDB.Update(account);
            return View();
        }

        [HttpGet]
        public ActionResult AddAccount()
        {
            var a = typeof(Account).GetProperties();
            return View();
        }

        [HttpPost]
        public ActionResult AddAccount(Account a)
        {
            if (ModelState.IsValid)
            {
                AccountsDB.Add(a);
                return RedirectToAction("Accounts");
            }
            return View(a);
        }

        #endregion

        #region Projects

        public ActionResult Projects()
        {
            return View(ProjectsDB.Projects.ToList());
        }

        public ActionResult UnconfirmedProjects()
        {
            return View("Projects", ProjectsDB.Projects.Where(x=>x.Status == Statuses.Unconfirmed).ToList());
        }

        public ActionResult CountOfUnconfirmedProjects()
        {
            int count = ProjectsDB.Projects.Where(x => x.Status == Statuses.Unconfirmed).Count();
            return Content(count==0?"":("("+count.ToString()+")"));
        }

        public ActionResult Confirm(int id)
        {
            ProjectsDB.Confirm(id);
            return RedirectToAction("UnconfirmedProjects");
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProject(Project a)
        {
            if (ModelState.IsValid)
            {
                ProjectsDB.Add(a);
                return RedirectToAction("Accounts");
            }
            return View(a);
        }

        #endregion

    }
}
