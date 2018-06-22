using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BVAppDAL.Models;

namespace BVAppDAL.DAL
{
    public class ParentStudentDAL
    {
        public bool Save(int pParentPartyId, int pStudentPartyId)
        {
            try
            {
                using (var bvConn = new bvappContext())
                {
                    var oParentStudentResult = bvConn.ParentStudent.SingleOrDefault(pnt => pnt.ParentPartyId == pParentPartyId
                    && pnt.ParentStudentId == pStudentPartyId);

                    if (oParentStudentResult == null)
                    {
                        ParentStudent oParentStudent = new ParentStudent();

                        oParentStudent.ParentStudentId = pParentPartyId;
                        oParentStudent.StudentPartyId = pStudentPartyId;
                        oParentStudent.CreatedDate = DateTime.Now;
                        oParentStudent.CreatedBy = "Admin";
                        oParentStudent.ModifiedDate = DateTime.Now;
                        oParentStudent.ModifiedBy = "Admin";


                        bvConn.ParentStudent.Add(oParentStudent);
                        bvConn.SaveChanges();
                    }
                    else
                    {
                        oParentStudentResult.ParentStudentId = pParentPartyId;
                        oParentStudentResult.StudentPartyId = pStudentPartyId;
                        oParentStudentResult.ModifiedDate = DateTime.Now;
                        oParentStudentResult.ModifiedBy = "Admin";

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
