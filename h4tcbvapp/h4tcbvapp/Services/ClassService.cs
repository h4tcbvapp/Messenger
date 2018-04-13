using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;
using h4tcbvapp.Classes;
using System;

namespace h4tcbvapp.Services
{
    public class ClassService
    {


        public ClassService() {
            
        }

        public ClassModel createClass(ClassModel classModel)
        {
            // todo
            classModel.Id = 1;

            return classModel;
        }

        public ClassModel updateClass(ClassModel classModel)
        {
            // todo

            return classModel;
        }

        public Boolean associateClassToGrade(int classId, int gradeid, DateTime startDate, DateTime endDate)
        {
            // todo

            return true;
        }

        [HttpGet]
        public ClassModel getClassById(int gradeId)
        {
            ClassModel classModel = new ClassModel { Id = 1, ClassName = "Kintergarten Math" };

            return classModel;
        }

        [HttpGet]
        public List<ClassModel> getClassesByGrade(int gradeId)
        {
            List<ClassModel> models = new List<ClassModel>();
            models.Add(new ClassModel { Id = 1, ClassName = "Kintergarten Math" });
            models.Add(new ClassModel { Id = 2, ClassName = "Kintergarten Science" });

            return models;
        }

        [HttpGet]
        public List<ClassModel> getClasses(String text)
        {
            List<ClassModel> models = new List<ClassModel>();
            models.Add(new ClassModel { Id = 1, ClassName = "Kintergarten Math" });
            models.Add(new ClassModel { Id = 2, ClassName = "Kintergarten Science" });

            return models;
        }

    }
}
