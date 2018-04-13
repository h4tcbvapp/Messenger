using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;
using h4tcbvapp.Classes;
using h4tcbvapp.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace h4tcbvapp.Controllers
{

    [Route("api/[controller]")]
    public class GradeController : Controller
    {
        private readonly IConfiguration _configuration;
        private GradeService _gradeService;


        public GradeController(IConfiguration configuration)
        {
            _configuration = configuration;
            _gradeService = new GradeService();
        }

        [HttpGet]
        public ActionResult getGrades()
        {
            List<GradeModel> models = _gradeService.getGrades();

            var result = new Dictionary<string, object>();
            result.Add("Grades", models);

            return Json(result);
        }
    }
}
