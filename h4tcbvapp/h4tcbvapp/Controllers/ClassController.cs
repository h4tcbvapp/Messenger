using System;
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
    public class ClassController : Controller
    {
        private readonly IConfiguration _configuration;
        private ClassService _classService;

        public ClassController(IConfiguration configuration)
        {
            _configuration = configuration;
            _classService = new ClassService();
        }

        [HttpGet("/api/[controller]/search")]
        public ActionResult getClasses(String text)
        {
            List<ClassModel> models = _classService.getClasses(text);

            var result = new Dictionary<string, object>();
            result.Add("Classes", models);

            return Json(result);
        }

        [HttpGet("/api/[controller]/search/byGrade/{gradeId}")]
        public ActionResult getClassesByGrade(int gradeId)
        {
            List<ClassModel> models = _classService.getClassesByGrade(gradeId);

            var result = new Dictionary<string, object>();
            result.Add("Classes", models);

            return Json(result);
        }

        [HttpGet("/api/[controller]/{classId}")]
        public ActionResult getClassById(int classId)
        {
            ClassModel model = _classService.getClassById(classId);

            var result = new Dictionary<string, object>();
            result.Add("Class", model);

            return Json(result);
        }

        [HttpPost]
        public ActionResult createClass([FromBody] ClassModel classModel)
        {
            ClassModel savedModel = _classService.createClass(classModel);

            var result = new Dictionary<string, object>();
            result.Add("Class", savedModel);

            return Json(result);
        }

        [HttpPut]
        public ActionResult updateClass(int classId, [FromBody] ClassModel classModel)
        {
            ClassModel savedModel = _classService.updateClass(classModel);

            var result = new Dictionary<string, object>();
            result.Add("Class", savedModel);

            return Json(result);
        }

        [HttpPut("/api/[controller]/{classId}/grade/{gradeId}")]
        public ActionResult associateClassToGrade(int classId, int gradeId, DateTime startDate, DateTime endDate)
        {
            Boolean success = _classService.associateClassToGrade(classId, gradeId, startDate, endDate);

            var result = new Dictionary<string, object>();
            result.Add("Result", success);
            result.Add("ResultMessage", "Successfully associated class to grade");

            return Json(result);
        }

    }
}
