using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BVAppDAL.Models;
using Newtonsoft.Json;

namespace BVAppDAL.DAL
{
    public class GradeDAL
    {
        public string GetGrades()
        {
            // all grades
            string json = string.Empty;

            try
            {
                using (var context = new bvappContext())
                {
                    var query = (from a in context.Grade
                                 orderby a.GradeId descending
                                 select a);

                    json = JsonConvert.SerializeObject(query);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return json;
        }

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
