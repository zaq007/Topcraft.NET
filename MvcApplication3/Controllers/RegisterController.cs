using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.Models;
using MvcApplication3.Models.Boundary;
using MvcApplication3.Models.Interfaces;

namespace MvcApplication3.Controllers
{
    public class RegisterController : Controller
    {
        //
        // GET: /Account/
        AccountRespository Accounts = new AccountRespository();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(RegisterAccount reg)
        {
            if (ModelState.IsValid)
            {
                if (Accounts.GetUser(reg.Email) != null)
                    return View("Index", reg);
                Account acc = new Account();
                acc.Email = reg.Email;
                acc.Password = reg.Password;
                Accounts.Add(acc);
                return RedirectToAction("Index");
            }
            return View("Index", reg);
        }


    }
}
