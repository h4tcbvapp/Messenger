using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BVAppDAL.Models;
using BVAppDAL.Models;

namespace BVAppDAL.DAL
{
    public class ClassDAL
    {
        public bool Save(string pClassName, int pGradeId)
        {
            try
            {
                using (var context = new bvappContext())
                {
                    var oClassResult = context.Class.SingleOrDefault(cls => cls.ClassName == pClassName);

                    if (oClassResult == null)
                    {
                        Class obj = new Class();

                        obj.ClassName = pClassName;
                        //obj.GradeId = pGradeId;
                        obj.CreatedDate = DateTime.Now;
                        obj.CreatedBy = "Admin";
                        obj.ModifiedDate = DateTime.Now;
                        obj.ModifiedBy = "Admin";

                        context.Class.Add(obj);
                        context.SaveChanges();
                    }
                    else
                    {
                        oClassResult.ClassName = pClassName;
                        //oClassResult.GradeId = pGradeId;
                        oClassResult.ModifiedDate = DateTime.Now;
                        oClassResult.ModifiedBy = "Admin";

                        context.SaveChanges();
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
