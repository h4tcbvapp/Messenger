using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BVAppDAL.Models;

namespace BVAppDAL.DAL
{
    public class StudentDAL
    {
        public string viewStudent(string searchParemeter)
        {

            try
            {
                using (var context = new bvappContext())
                {
                    var query = (from a in context.Student
                                 join p in context.Party on a.PartyId equals p.PartyId
                                 where a.StudentIdentifier == searchParemeter || p.FirstName == searchParemeter ||
                                       p.LastName == searchParemeter
                                 select a);

                    string json = JsonConvert.SerializeObject(query);
                    return json;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void updateStudent(int partyId, string studentIdentifier)
        {
            try
            {
                var context = new bvappContext();

                var result = context.Party.SingleOrDefault(b => b.PartyId == partyId);
                if (result != null && result.PartyId > 0)
                {
                    var result1 = context.Student.SingleOrDefault(b => b.PartyId == result.PartyId);
                    result1.StudentIdentifier = studentIdentifier;
                    result1.ModifiedDate = DateTime.Now;
                    result1.ModifiedBy = "Admin";

                    context.SaveChanges();
                }
                else
                {
                    var student = new Student();
                    student.StudentIdentifier = studentIdentifier;
                    student.CreatedDate = DateTime.Now;
                    student.CreatedBy = "Admin";
                    student.ModifiedDate = DateTime.Now;
                    student.ModifiedBy = "Admin";

                    context.Student.Add(student);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void UpdateStudentClass(int studentId, int classId, DateTime startdate, DateTime enddate)
        {
            var context = new bvappContext();
            var result = context.StudentClass.SingleOrDefault(b => b.PartyId == studentId && b.ClassId == classId);
            if (result != null)
            {
                result.StartDate = startdate;
                result.EndDate = enddate;
                result.ModifiedDate = DateTime.Now;
                result.ModifiedBy = "Admin";

                context.SaveChanges();
            }
            else
            {
                var studentclass = new StudentClass();
                studentclass.ClassId = classId;
                studentclass.PartyId = studentId;
                studentclass.StartDate = startdate;
                studentclass.EndDate = enddate;
                studentclass.CreatedDate = DateTime.Now;
                studentclass.CreatedBy = "Admin";
                studentclass.ModifiedDate = DateTime.Now;
                studentclass.ModifiedBy = "Admin";

                context.StudentClass.Add(studentclass);
                context.SaveChanges();
            }
        }
    }
}
