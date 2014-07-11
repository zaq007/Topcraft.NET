using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;


namespace MvcApplication3.Models.Boundary
{
    public class AdRepository
    {
        MainContext DB = new MainContext();

        public List<Ad> GetByOwner(Account owner)
        {
            return DB.Ads.Where(x => x.OwnerId == owner.Id).ToList();
        }

        public List<Price> GetPrices()
        {
            return DB.Prices.ToList();
        }


        internal string Add(Ad ad, int Value, Account CurrentUser)
        {
            var Cost = DB.Prices.FirstOrDefault(x => x.Goal == ad.Goal && x.Position == ad.Position).Cost;
            if(ad.Goal == Goals.Clicks)
                Cost = Cost * Value;
            else
            if(ad.Goal == Goals.View)
                Cost = Cost * Value / 1000;
            else
            if(ad.Goal == Goals.Time)
                Cost = Cost * Value;
            if (CurrentUser.Wallet < Cost)
                return "Недостаточно средств";
            CurrentUser.Wallet -= Cost;
            ad.OwnerId = CurrentUser.Id;
            ad.Start = DateTime.Now;
            if(ad.Goal == Goals.Clicks)
                ad.EndClicks = Value;
            else
            if(ad.Goal == Goals.Time)
                ad.EndTime = ad.Start.AddDays(Value);
            else
                ad.EndViews = Value;

            try
            {
                DB.Ads.Add(ad);
                DB.SaveChanges();
                return "Dobavleno";
            }
            catch (DbUpdateException e)
            {
                CurrentUser.Wallet += Cost;
                return "Try again later"+e.InnerException.Message;
            }
        }
    }
}