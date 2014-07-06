using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using MvcApplication3.Models.Interfaces;

namespace MvcApplication3.Global.Auth
{
    public class UserProvider : IPrincipal
    {
        private UserIndentity userIdentity { get; set; }

        #region IPrincipal Members

        public IIdentity Identity
        {
            get
            {
                return userIdentity;
            }
        }

        #endregion


        public UserProvider(string name, IRepository repository)
        {
            userIdentity = new UserIndentity();
            userIdentity.Init(name, repository);
        }


        public override string ToString()
        {
            return userIdentity.Name;
        }


        public bool IsInRole(string role)
        {
            var roles = role.Split(',');
            if (userIdentity.User == null)
            {
                return false;
            }
            if(roles.Any(x => string.Compare(x,userIdentity.CurrentUser.RoleName.ToString(), false) == 0))
                return true;
            return false;
        }
    }
}