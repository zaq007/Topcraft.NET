using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using MvcApplication3.Models;

namespace MvcApplication3.Global.Auth
{
    public interface IUserProvider
    {
        Account User { get; set; }
    }
}