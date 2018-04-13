using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BVAppDAL.Models;

namespace BVAppDAL.DAL
{
    public class PhoneDAL
    {
        public bool Save(string phoneNumber, int carrierId, int partyId)
        {
            try
            {
                using (var bvConn = new bvappContext())
                {
                    var oPhoneResult = bvConn.Phone.SingleOrDefault(phone => phone.PhoneNumber == phoneNumber);

                    if (oPhoneResult == null)
                    {
                        Phone phone = new Phone();

                        phone.PhoneNumber = phoneNumber;
                        phone.PhoneCareerId = carrierId;
                        phone.PartyId = partyId;
                        phone.CreatedDate = DateTime.Now;
                        phone.CreatedBy = "Admin";
                        phone.ModifiedDate = DateTime.Now;
                        phone.ModifiedBy = "Admin";


                        bvConn.Phone.Add(phone);
                        bvConn.SaveChanges();
                    }
                    else
                    {
                        oPhoneResult.PhoneNumber = phoneNumber;
                        oPhoneResult.ModifiedDate = DateTime.Now;
                        oPhoneResult.ModifiedBy = "Admin";

                        bvConn.SaveChanges();
                    }

                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

            return true;
        }
    }
}
