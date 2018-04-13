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
    public class ClassController : Controller
    {
        private readonly IConfiguration _configuration;

        public ClassController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult getClassesByGrade(int gradeId)
        {
            List<ClassModel> models = new List<ClassModel>();
            models.Add(new ClassModel { Id = 1, ClassName = "Kintergarten Math" });
            models.Add(new ClassModel { Id = 2, ClassName = "Kintergarten Science" });

            var result = new Dictionary<string, object>();
            result.Add("Classes", models);

            return Json(result);
        }

        [HttpPost]
        public ActionResult createClass([FromBody] ClassModel classModel)
        {
            // todo
            classModel.Id = 1;


            var result = new Dictionary<string, object>();
            result.Add("Class", classModel);

            return Json(result);
        }

        [HttpPut]
        public ActionResult updateClass(int classId, [FromBody] ClassModel classModel)
        {
            // todo


            var result = new Dictionary<string, object>();
            result.Add("Class", classModel);

            return Json(result);
        }

    }
}
