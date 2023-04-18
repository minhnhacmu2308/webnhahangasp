using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using webnhahangasp.Models;

namespace webnhahangasp.Repository
{
    public class UserRepository
    {
        WebNhaHangDbContext myDb = new WebNhaHangDbContext();

        public bool checkLogin(string email, string password)
        {
            var obj = myDb.users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (obj == null) { return false; }
            return true;
        }



        public User getUserByEmail(string email)
        {
            return myDb.users.FirstOrDefault(x => x.Email.Equals(email));
        }

        public void Add(User user)
        {
            myDb.users.Add(user);
            myDb.SaveChanges();
        }

        public string md5(string password)
        {
            MD5 md = MD5.Create();
            byte[] inputString = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hash = md.ComputeHash(inputString);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x"));
            }
            return sb.ToString();
        }



        public bool checkExistEmail(string email)
        {
            var user = myDb.users.FirstOrDefault(x => x.Email == email);
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}