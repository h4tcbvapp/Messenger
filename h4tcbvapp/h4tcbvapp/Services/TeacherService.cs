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
    public class TeacherService
    {

        public TeacherModel createTeacher(TeacherModel teacherModel)
        {
            // todo
            teacherModel.Id = 1;

            return teacherModel;
        }

        public TeacherModel updateTeacher(TeacherModel teacherModel)
        {
            // todo

            return teacherModel;
        }

        public Boolean associateTeacherToGrade(int teacherId, int classId, DateTime startDate, DateTime endDate)
        {
            // todo

            return true;
        }

        [HttpGet]
        public TeacherModel getTeacherById(int teacherId)
        {
            TeacherModel model = new TeacherModel { Id = 1, TeacherIdentifier = "ABC", FirstName = "Teacher", LastName = "One", EmailAddress = "email1@localhost" };

            return model;
        }

        [HttpGet]
        public List<TeacherModel> getTeachersByClass(int classId)
        {
            List<TeacherModel> models = new List<TeacherModel>();
            models.Add(new TeacherModel { Id = 1, TeacherIdentifier = "ABC", FirstName = "Teacher", LastName = "One", EmailAddress = "email1@localhost" });
            models.Add(new TeacherModel { Id = 2, TeacherIdentifier = "XYZ", FirstName = "Teacher", LastName = "Two", EmailAddress = "email2@localhost" });

            return models;
        }

        [HttpGet]
        public List<TeacherModel> getTeachers(String text)
        {
            List<TeacherModel> models = new List<TeacherModel>();
            models.Add(new TeacherModel { Id = 1, TeacherIdentifier = "ABC", FirstName = "Teacher", LastName = "One", EmailAddress = "email1@localhost" });
            models.Add(new TeacherModel { Id = 2, TeacherIdentifier = "XYZ", FirstName = "Teacher", LastName = "Two", EmailAddress = "email2@localhost" });

            return models;
        }

    }
}
