using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BVAppDAL.Models;

namespace BVAppDAL.DAL
{
    public class ParentDAL
    {
        public bool Save(int pPartyId)
        {
            try
            {
                using (var bvConn = new bvappContext())
                {
                    var oParentResult = bvConn.Parent.SingleOrDefault(pnt => pnt.PartyId == pPartyId);

                    if (oParentResult == null)
                    {
                        Parent oParent = new Parent();

                        oParent.PartyId = pPartyId;
                        oParent.CreatedDate = DateTime.Now;
                        oParent.CreatedBy = "Admin";
                        oParent.ModifiedDate = DateTime.Now;
                        oParent.ModifiedBy = "Admin";

                        bvConn.Parent.Add(oParent);
                        bvConn.SaveChanges();
                    }
                    else
                    {
                        oParentResult.PartyId = pPartyId;
                        oParentResult.ModifiedDate = DateTime.Now;
                        oParentResult.ModifiedBy = "Admin";

                        bvConn.SaveChanges();
                    }

                }
            }
            catch(Exception Ex)
            {
                throw Ex;
            }

            return true;
        }
    }
}
