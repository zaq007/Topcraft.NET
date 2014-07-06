using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication3.Models.Interfaces
{
    public interface IRepository
    {
        IQueryable<Account> Accounts { get; }

        bool Add(Account instance);

        Account Login(string email, string pass);

        Account GetUser(string email);
    }
}