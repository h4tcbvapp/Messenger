using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;
using h4tcbvapp.Classes;

namespace h4tcbvapp.Services
{
    public class GradeService
    {
        public List<GradeModel> getGrades()
        {
            List<GradeModel> models = new List<GradeModel>();
            models.Add(new GradeModel { Id = 1, GradeName = "Kintergarten" });
            models.Add(new GradeModel { Id = 2, GradeName = "Grade 1" });

            return models;
        }
    }
}
