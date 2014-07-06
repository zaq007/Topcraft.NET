using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.Global;
using MvcApplication3.Models.Boundary;

namespace MvcApplication3.Controllers
{
    public class VotesController : Controller
    {
        //
        // GET: /Votes/

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
    }
}
