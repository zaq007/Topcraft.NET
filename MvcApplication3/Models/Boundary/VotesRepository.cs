using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication3.Models.Boundary
{
    public class VotesRepository
    {

        MainContext DB = new MainContext();


        public string Vote(int id, string Nickname, string uid, string ip)
        {
            Voter voter;
            try
            {
                voter = DB.Voters.Where(x => x.Vk == uid).ToArray()[0];
            }
            catch
            {
                voter = new Voter();
                voter.Vk = uid;
                DB.Voters.Add(voter);
            }
            if (DateTime.Now - voter.LastVote < new TimeSpan(24, 0, 0))
                return "С момента последнего голосования должно пройти не менее 24 часов";
            voter.LastVote = DateTime.Now;
            DB.Votes.Add(new Vote()
            {
                ProjectId = id,
                Nickname = Nickname,
                Date = DateTime.Now,
                Ip = ip
            });
            DB.SaveChanges();
            return "Вы успешно проголосовали";
        }
    }
}