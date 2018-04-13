using System;
using System.Collections.Generic;
//using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BVAppDAL.Models;

namespace BVAppDAL.DAL
{
    public class AccountDAL
    {
        public Boolean CheckLogin(string userName, string password)
        {
            byte[] str = PasswordToSSH(password);

            using (var context = new bvappContext())
            {
                var query = (from a in context.Account
                             join p in context.Party on a.PartyId equals p.PartyId
                    where a.UserName == userName && a.Password == str && p.IsActive == "Y"
                    select a).FirstOrDefault();

                if (query!= null && (!string.IsNullOrEmpty(query.UserName)))
                    return true;

                return false;
            }
        }

        public Boolean CreateLogin(int partyTYpeId, string userName, string password)
        {
            var context = new bvappContext();
            byte[] str = PasswordToSSH(password);

            var result = context.Account.SingleOrDefault(b => b.UserName == userName);
            if (result != null)
            {
                result.Password = str;
                result.ModifiedDate = DateTime.Now;
                result.ModifiedBy = "Admin";

                context.SaveChanges();
            }
            else
            {
                var account = new Account();
                account.PartyId = partyTYpeId;
                account.UserName = userName;
                account.Password = PasswordToSSH(password);
                account.CreatedDate = DateTime.Now;
                account.CreatedBy = "Admin";
                account.ModifiedDate = DateTime.Now;
                account.ModifiedBy = "Admin";

                context.Account.Add(account);
                context.SaveChanges();
            }

            return true;
        }

        private byte[] PasswordToSSH(string data)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(data);
            using (var alg = SHA512.Create())
            {
                alg.ComputeHash(bytes);
                return alg.Hash;
            }
        }
    }
}
