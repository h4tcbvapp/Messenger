using System;
using System.Collections.Generic;
//using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BVAppDAL.Models;
using Newtonsoft.Json;

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

                if (query != null && (!string.IsNullOrEmpty(query.UserName)))
                    return true;

                return false;
            }
        }

        public string LoginSelect(string userName, string password)
        {
            string sLogin = "";
            try
            {
                byte[] str = PasswordToSSH(password);

                using (var context = new bvappContext())
                {
                    var query = (from a in context.Account
                                 join p in context.Party on a.PartyId equals p.PartyId
                                 where a.UserName == userName && a.Password == str && p.IsActive == "Y"
                                 select a).FirstOrDefault();

                    if (query != null && (!string.IsNullOrEmpty(query.UserName)))
                    {
                        sLogin = JsonConvert.SerializeObject(query);
                    }

                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return sLogin;
        }

        public string UserSelect(string userName, string password)
        {
            string sLogin = "";
            try
            {
                byte[] str = PasswordToSSH(password);

                using (var context = new bvappContext())
                {
                    var query = (from a in context.Account
                                 join p in context.Party on a.PartyId equals p.PartyId
                                 where a.UserName == userName && a.Password == str && p.IsActive == "Y"
                                 select new
                                 {
                                     Name = string.Concat(p.FirstName, " ", p.LastName).Trim(),
                                     Email = p.EmailAddress
                                 }
                                ).FirstOrDefault();

                    if (query != null && (!string.IsNullOrEmpty(query.Name)))
                    {
                        sLogin = JsonConvert.SerializeObject(query);
                    }

                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return sLogin;
        }


        /// <summary>
        /// Retrieve Recipient information formatted for sending an SMTP message
        /// </summary>
        /// <returns>A Json string representation of the selected recipient.</returns>
        /// <param name="partyId">Party identifier of the intended recipient.</param>
        public string RecipientSelect(int partyId)
        {
            string recip = "";
            const string addressSep = "@";
            using (var context = new bvappContext())
            {
                var query = (from a in context.Account
                             join p in context.Party on a.PartyId equals p.PartyId
                             join phn in context.Phone on a.PartyId equals phn.PartyId
                             join pcr in context.PhoneCareer on phn.PhoneCareerId equals pcr.PhoneCareerId
                             where a.PartyId == partyId && p.IsActive == "Y"
                             select new
                             {
                                 a.PartyId,
                                 RecipName = string.Concat(p.FirstName, " ", p.LastName).Trim(),
                                 RecipAddress = string.Concat(phn.PhoneNumber,
                                                              pcr.Smsgateway.StartsWith(addressSep, StringComparison.CurrentCulture)
                                                                ? string.Empty
                                                                : addressSep
                                                              , pcr.Smsgateway).Trim(),
                                 phn.PhoneNumber,
                                 SmsGateway = pcr.Smsgateway
                             }
                            ).FirstOrDefault();

                if (query != null && (!string.IsNullOrEmpty(query.RecipAddress)))
                {
                    recip = JsonConvert.SerializeObject(query);
                }

            }
            return recip;
        }

        public Boolean CreateLogin(int partyId, string userName, string password)
        {
            try
            {
                var context = new bvappContext();
                byte[] str = PasswordToSSH(password);

                var result = context.Account.SingleOrDefault(b => b.UserName.ToLower() == userName.ToLower());
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
                    account.PartyId = partyId;
                    account.UserName = userName.ToLower();
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
            catch (Exception Ex)
            {
                throw Ex;
            }
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
