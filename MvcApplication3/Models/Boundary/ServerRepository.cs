using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication3.Models.Boundary
{
    public class ServerRepository
    {
        ServerContext DB = new ServerContext();

        public bool Add(Server s)
        {
            try
            {
                foreach (int i in s.ModsId)
                {
                    var mod = GetModById(i);
                    if(mod != null)
                        s.Mods.Add(mod);
                }
                DB.Servers.Add(s);
                DB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Mod GetModById(int id)
        {
            try
            {
                return DB.Mods.Where(x => x.Id == id).ToArray()[0];
            }
            catch
            {
                return null;
            }
        }

        public List<Mod> GetMods()
        {
            return DB.Mods.ToList();
        }

    }
}