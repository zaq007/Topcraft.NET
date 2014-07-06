using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication3.Models.Interfaces;

namespace MvcApplication3.Models.Boundary
{
    public class AccountRespository : IRepository
    {
        AccountContext DB = new AccountContext();

        public IQueryable<Account> Accounts
        {
            get
            {
                return DB.Entries;
            }
        }

        public bool Add(Account instance)
        {
            try
            {
                DB.Entries.Add(instance);
                DB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Account Login(string email, string pass)
        {
            return DB.Entries.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0 && string.Compare(p.Password, pass, false) == 0);
        }


        public Account GetUser(string email)
        {
            return DB.Entries.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0);
        }

        public Account GetById(int id)
        {
            return DB.Entries.FirstOrDefault(p => p.Id == id);
        }

        internal void Update(Account account)
        {
            var arr = typeof(Account).GetProperties();
            var acc = DB.Entries.Where(x => x.Id == account.Id).ToArray()[0];
            for (int i = 1; i < arr.Count(); i++)
            {
                arr[i].SetValue(acc, arr[i].GetValue(account));
            }
            DB.SaveChanges();
        }
    }
}