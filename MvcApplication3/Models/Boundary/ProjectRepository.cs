using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using MvcApplication3.Global.Auth;
using Ninject;

namespace MvcApplication3.Models.Boundary
{
    public class ProjectRepository
    {
        MainContext DB = new MainContext();
        AccountRespository AR = new AccountRespository();

        public IQueryable<Project> Projects
        {
            get
            {
                return DB.Projects;
            }
        }

        public bool Add(Project p)
        {
            try
            {
                DB.Projects.Add(p);
                DB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        internal void Confirm(int id)
        {
            DB.Projects.Where(x => x.Id == id).ToArray()[0].Status = Statuses.Ordinary;
            DB.SaveChanges();
        }

        public List<Project> GetUserProjects(Account curr)
        {
            return DB.Projects.Where(x => x.Owner.Id == curr.Id).ToList();
        }

        internal List<Project> GetProjectsForMainPage()
        {
            return DB.Projects.Where(x => x.Status != Statuses.Unconfirmed && x.Status != Statuses.Hidden).ToList();
        }

        public string Update(int id, string name, string description, string url, string banner, Account CurrentUser)
        {
            Project p = GetById(id);
            if (CurrentUser.Id != p.Owner.Id)
                return "Access Denied!";
            if (name != "")
                p.Name = name;
            if (description != "")
                p.Description = description;
            if (url != "")
            {
                try
                {
                    new Uri(url);
                }
                catch
                {
                    url = "http://" + url;
                    try
                    {
                        new Uri(url);
                    }
                    catch
                    {
                        return "Wrong URL";
                    }
                }
                p.SiteUrl = url;
            }
            if (banner != "" && banner != null)
                p.BannerUrl = banner;
            DB.SaveChanges();
            return "Saved";
        }

        internal Project GetById(int Id)
        {
            try
            {
                return DB.Projects.Where(x => x.Id == Id).ToArray()[0];
            }
            catch
            {
                return null;
            }
        }

        public string Hide(int id, Account CurrentUser)
        {
            Project p = GetById(id);
            if (CurrentUser.Id != p.Owner.Id)
                return "Access Denied!";
            p.Status = Statuses.Hidden;
            DB.SaveChanges();
            return "Hided";
        }

        public string Transfer(int id, string new_owner, Account CurrentUser)
        {
            Project p = GetById(id);
            if (CurrentUser.Id != p.Owner.Id)
                return "Access Denied!";
            Account New = AR.GetUser(new_owner);
            if (New.Id != CurrentUser.Id)
            {
                p.OwnerID = New.Id;
                DB.SaveChanges();   
            }
            return "Transfered";
        }

        public string Delete(int id, Account CurrentUser)
        {
            Project p = GetById(id);
            if (CurrentUser.Id != p.Owner.Id)
                return "Access Denied!";
            DB.Projects.Remove(DB.Projects.Where(x => x.Id == id).ToArray()[0]);
            DB.SaveChanges();
            return "Deleted";
        }

        public string NewUrl(int id, string url, Account CurrentUser)
        {
            Project p = GetById(id);
            if (CurrentUser.Id != p.Owner.Id)
                return "Access Denied!";
            try
            {
                new Uri(url);
            }
            catch
            {
                url = "http://" + url;
                try
                {
                    new Uri(url);
                }
                catch
                {
                    return "Wrong URL";
                }
            }
            p.RewardUrl = url;
            DB.SaveChanges();
            return "Changed";
        }

        private string GenerateHash(string value)
        {
            var data = System.Text.Encoding.ASCII.GetBytes(value);
            data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            return Convert.ToBase64String(data);
        }

        public string NewApiHash(int id, Account CurrentUser)
        {
            Project p = GetById(id);
            if (CurrentUser.Id != p.Owner.Id)
                return "Access Denied!";
            p.RewardHash = GenerateHash(DateTime.Now.ToString());
            DB.SaveChanges();
            return p.RewardHash;
        }
    }
}