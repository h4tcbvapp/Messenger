using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;
using h4tcbvapp.Classes;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace h4tcbvapp.Controllers
{

    [Route("api/[controller]")]
    public class GradeController : Controller
    {
        private readonly IConfiguration _configuration;

        public GradeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult getGrades()
        {
            List<GradeModel> grades = new List<GradeModel>();
            grades.Add(new GradeModel { Id = 1, GradeName = "Kintergarten" });
            grades.Add(new GradeModel { Id = 2, GradeName = "Grade 1" });

            var result = new Dictionary<string, object>();
            result.Add("Grades", grades);

            return Json(result);
        }
    }
}
