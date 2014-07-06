using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.Models;
using Ninject;

namespace MvcApplication3.Global.Auth
{
    public class AutorizeAttribute : AuthorizeAttribute
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

        public string RequiredRole;
        public int YourCustomValue;
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException("httpContext");
            if (httpContext.User.Identity.IsAuthenticated == false) return false;
            return string.Compare(CurrentUser.RoleName.ToString(), RequiredRole, false) == 0;
        }
    }
}