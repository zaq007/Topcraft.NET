using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.Global;
using MvcApplication3.Global.Auth;
using MvcApplication3.Models;
using MvcApplication3.Models.Boundary;
using Ninject;

namespace MvcApplication3.Controllers
{
    public class VotesController : Controller
    {
        //
        // GET: /Votes/

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
        VotesRepository VR = new VotesRepository();

        public ActionResult Index(string Nickname, int Id)
        {
            ViewBag.Project = PR.GetById(Id);
            ViewBag.Nickname = Nickname;
            return View();
        }

        public ActionResult Vote(int id, string Nickname, string hash, string uid)
        {
            string message = "Error";
            if (VK.IsValid(uid, hash))
            {
                message = VR.Vote(id, Nickname, uid, Request.UserHostAddress);
            }
            return RedirectPermanent("/Projects/Index/" + id + "/?Message=" + message);
        }

        [Authorize(Roles="Admin,Member")]
        [HttpPost]
        public string Test(int id, string Nickname)
        {
            Project a = PR.GetById(id);
            if(a.Owner == CurrentUser)
                return VR.Reward(a, Nickname);
            return "Access denied!";
        }

        [HttpPost]
        public string MyTest(string signature, string username, string timestamp)
        {
            return signature + "\n" + username + "\n" + timestamp;
        }
    }
}
