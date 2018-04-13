using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BVAppDAL.Models;

namespace BVAppDAL.DAL
{
    public class PartyDAL
    {
        public string PartyExist(int partyId, string name)
        {
            string json;

            try
            {
                using (var context = new bvappContext())
                {
                    var query = (from b in context.Party
                                 where b.PartyId == partyId || b.FirstName == name || b.LastName == name || b.EmailAddress == name
                                 select b);
                    json = JsonConvert.SerializeObject(query);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return json;
        }

        public void UpdateParty(int partyId, int partyTypeId, string firstName, string middleName, string lastName, string title,
            string emailAddress, string isActive)
        {
            try
            {
                var context = new bvappContext();

                var result = context.Party.SingleOrDefault(b => b.PartyId == partyId);
                if (result != null)
                {
                    result.FirstName = firstName;
                    result.MiddleName = middleName;
                    result.LastName = lastName;
                    result.Title = title;
                    result.EmailAddress = emailAddress;
                    result.IsActive = isActive;
                    result.ModifiedDate = DateTime.Now;
                    result.ModifiedBy = "Admin";

                    context.SaveChanges();
                }
                else
                {
                    var party = new Party();
                    party.FirstName = firstName;
                    party.MiddleName = middleName;
                    party.LastName = lastName;
                    party.Title = title;
                    party.EmailAddress = emailAddress;
                    party.IsActive = isActive;
                    party.CreatedDate = DateTime.Now;
                    party.CreatedBy = "Admin";
                    party.ModifiedDate = DateTime.Now;
                    party.ModifiedBy = "Admin";

                    context.Party.Add(party);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}
