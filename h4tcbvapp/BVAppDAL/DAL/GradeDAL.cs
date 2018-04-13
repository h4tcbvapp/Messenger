using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BVAppDAL.Models;

namespace BVAppDAL.DAL
{
    public class GradeDAL
    {
        public bool Save(string pGradeName)
        {
            try
            {
                using (var bvConn = new bvappContext())
                {
                    var oGradeResult = bvConn.Grade.SingleOrDefault(grd => grd.GradeName == pGradeName);

                    if (oGradeResult == null)
                    {
                        Grade oGrade = new Grade();

                        oGrade.GradeName = pGradeName;
                        oGrade.CreatedDate = DateTime.Now;
                        oGrade.CreatedBy = "Admin";
                        oGrade.ModifiedDate = DateTime.Now;
                        oGrade.ModifiedBy = "Admin";


                        bvConn.Grade.Add(oGradeResult);
                        bvConn.SaveChanges();
                    }
                    else
                    {
                        oGradeResult.GradeName = pGradeName;
                        oGradeResult.ModifiedDate = DateTime.Now;
                        oGradeResult.ModifiedBy = "Admin";

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
