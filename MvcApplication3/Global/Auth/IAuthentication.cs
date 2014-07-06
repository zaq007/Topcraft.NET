using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using MvcApplication3.Models;

namespace MvcApplication3.Global.Auth
{
    public interface IAuthentication
    {
        /// <summary>
        /// Конекст (тут мы получаем доступ к запросу и кукисам)
        /// </summary>
        HttpContext HttpContext { get; set; }

        Account Login(string login, string password);

        Account Login(string login);

        void LogOut();

        IPrincipal CurrentUser { get; }
    }
}