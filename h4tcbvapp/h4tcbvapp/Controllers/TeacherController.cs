using System;
using System.Collections.Generic;
using System.Linq;
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
    public class TeacherController : Controller
    {
        private readonly IConfiguration _config;
        private TeacherService _teaService;

        public TeacherController(IConfiguration configuration)
        {
            _config = configuration;
            _teaService = new TeacherService();
        }

        [HttpGet("/api/[controller]/search")]
        public ActionResult getTeachers(String text)
        {
            List<TeacherModel> models = _teaService.getTeachers(text);

            var result = new Dictionary<string, object>();
            result.Add("Teachers", models);

            return Json(result);
        }

        [HttpGet("/api/[controller]/search/byClass/{classId}")]
        public ActionResult getTeachersByClass(int classId)
        {
            List<TeacherModel> models = _teaService.getTeachersByClass(classId);

            var result = new Dictionary<string, object>();
            result.Add("Teachers", models);

            return Json(result);
        }

        [HttpGet("/api/[controller]/{teacherId}")]
        public ActionResult getTeacherById(int teacherId)
        {
            TeacherModel model = _teaService.getTeacherById(teacherId);

            var result = new Dictionary<string, object>();
            result.Add("Teacher", model);

            return Json(result);
        }

        [HttpPost]
        public ActionResult createTeacher([FromBody] TeacherModel teacherModel)
        {
            TeacherModel savedModel = _teaService.createTeacher(teacherModel);

            var result = new Dictionary<string, object>();
            result.Add("Teacher", savedModel);

            return Json(result);
        }

        [HttpPut]
        public ActionResult updateTeacher(int teacherId, [FromBody] TeacherModel teacherModel)
        {
            TeacherModel savedModel = _teaService.updateTeacher(teacherModel);

            var result = new Dictionary<string, object>();
            result.Add("Teacher", savedModel);

            return Json(result);
        }

        [HttpPut("/api/[controller]/{teacherId}/class/{classId}")]
        public ActionResult associateTeacherToClass(int teacherId, int classId, DateTime startDate, DateTime endDate)
        {
            Boolean success = _teaService.associateTeacherToGrade(teacherId, classId, startDate, endDate);

            var result = new Dictionary<string, object>();
            result.Add("Result", success);
            result.Add("ResultMessage", "Successfully associated teacher to class");

            return Json(result);
        }
    }
}
