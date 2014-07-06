using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MvcApplication3.Models.Boundary
{
    public class VotesRepository
    {

        MainContext DB = new MainContext();
        ProjectRepository PR = new ProjectRepository();

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
            Reward(PR.GetById(id), Nickname);
            return "Вы успешно проголосовали";
        }

        public string Reward(Project p, string Nickname)
        {
            if (p.RewardUrl == null || p.RewardHash == null)
                return "Error";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(p.RewardUrl);
                request.Method = "POST";
                request.Timeout = 100000;
                request.ContentType = "application/x-www-form-urlencoded";
                var Timestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                string post = "username="+Nickname+"&timestamp="+Timestamp+"&signature="+Encoding.UTF8.GetString(SHA1.Create().ComputeHash(Encoding.ASCII.GetBytes(Nickname+Timestamp+p.RewardHash)));
                byte[] bytes = Encoding.UTF8.GetBytes(post);
                request.ContentLength = bytes.Length;
                request.GetRequestStream().Write(bytes, 0, bytes.Length);
                request.GetRequestStream().Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
            catch
            {
                return "Error";
            }
        }
    }
}