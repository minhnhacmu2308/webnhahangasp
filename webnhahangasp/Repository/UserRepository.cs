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

        public User checkLogin(string email, string password)
        {
            var obj = myDb.users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (obj != null) { return obj; }
            return null;
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

        public void Update(User user)
        {
            var obj = myDb.users.FirstOrDefault(x => x.Email == user.Email);
            obj.Fullname = user.Fullname;
            obj.Updated_at = DateTime.Now;
            obj.Address = user.Address;
            obj.Gender = user.Gender;
            obj.Phone = user.Phone;
            myDb.SaveChanges();
        }

        public bool checkExistEmail(string email, int phoneNumber)
        {
            var user = myDb.users.FirstOrDefault(x => x.Email == email);
            if (user != null)
            {
                return true;
            }
            var checkPhone = myDb.users.FirstOrDefault(x => x.Phone == phoneNumber);
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}