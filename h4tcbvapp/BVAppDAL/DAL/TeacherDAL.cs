using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BVAppDAL.Models;

namespace BVAppDAL.DAL
{
    public class TeacherDAL
    {
        public void updateTeacher(int partyId, string teacherIdentifier, string availableHoursStart, string availableHoursEnd)
        {
            try
            {
                var context = new bvappContext();

                var result = context.Teacher.SingleOrDefault(b => b.TeacherIdentifier == teacherIdentifier);
                if (result != null)
                {
                    result.AvailHoursStart = availableHoursStart;
                    result.AvailHoursEnd = availableHoursEnd;
                    result.ModifiedDate = DateTime.Now;
                    result.ModifiedBy = "Admin";

                    context.SaveChanges();
                }
                else
                {
                    var teacher = new Teacher();
                    teacher.TeacherIdentifier = teacherIdentifier;
                    teacher.AvailHoursStart = availableHoursStart;
                    teacher.AvailHoursEnd = availableHoursEnd;
                    teacher.PartyId = partyId;
                    teacher.CreatedDate = DateTime.Now;
                    teacher.CreatedBy = "Admin";
                    teacher.ModifiedDate = DateTime.Now;
                    teacher.ModifiedBy = "Admin";

                    context.Teacher.Add(teacher);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void updateTeacherClass(int teacherId, int classId, DateTime startdate, DateTime enddate)
        {
            try
            {
                var context = new bvappContext();
                var result = context.TeacherClass.SingleOrDefault(b => b.ClassId == classId && b.TeacherPartyId == teacherId);
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
                    var teacherclass = new TeacherClass();
                    teacherclass.ClassId = classId;
                    teacherclass.TeacherPartyId = teacherId;
                    teacherclass.StartDate = startdate;
                    teacherclass.EndDate = enddate;
                    teacherclass.CreatedDate = DateTime.Now;
                    teacherclass.CreatedBy = "Admin";
                    teacherclass.ModifiedDate = DateTime.Now;
                    teacherclass.ModifiedBy = "Admin";
                    context.TeacherClass.Add(teacherclass);
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
