using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MvcApplication3.Global
{
    public static class VK
    {

        public static string AppId = "XXXXX";

        public static string SecretKey = "XXXXX";

        public static bool IsValid(string UserId, string Hash)
        {
            var data = System.Text.Encoding.ASCII.GetBytes(AppId+UserId+SecretKey);
            data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            return String.Compare(Hash, Encoding.UTF8.GetString(data)) == 0;
        }
    }
}