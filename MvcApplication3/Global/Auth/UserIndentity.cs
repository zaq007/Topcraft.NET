using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using MvcApplication3.Models;
using MvcApplication3.Models.Interfaces;
using Ninject;

namespace MvcApplication3.Global.Auth
{
    public class UserIndentity : IIdentity, IUserProvider
    {
        public Account User { get; set; }


        public string AuthenticationType
        {
            get
            {
                return typeof(Account).ToString();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return User != null;
            }
        }

        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.Email;
                }
                //иначе аноним
                return "anonym";
            }
        }

        public void Init(string email, IRepository repository)
        {
            if (!string.IsNullOrEmpty(email))
            {
                User = repository.GetUser(email);
            }
        }

        [Inject]
        public IAuthentication Auth { get; set; }

        public Account CurrentUser
        {
            get
            {
                return User;
            }
        }
    }
}