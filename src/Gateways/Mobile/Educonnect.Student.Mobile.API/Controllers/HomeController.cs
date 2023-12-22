using Educonnect.Student.Mobile.API.Services.Institute;
using Educonnect.Student.Mobile.API.Services.Student;
using InstituteGrpcService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentGrpcService;
using CourseGrpcService;
using Educonnect.Core.Models;
using System.Security.Claims;

namespace Educonnect.Student.Mobile.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IInstituteService _instituteService;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        public HomeController(IInstituteService instituteService, IStudentService studentService, ICourseService courseService)
        {
            _instituteService = instituteService;
            _studentService = studentService;
            _courseService = courseService;
        }
        [Route("home/institutes")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetInstitutes()
        {
            var institutes = await _instituteService.GetInstitutes();
            return Ok(new ResponseModel { Status = "success", Message = "User created successfully!", Data = institutes });
        }
        [Route("students")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentService.GetStudents();
            return Ok(new ResponseModel { Status = "success", Message = "", Data = students });
        }

        [Route("Courses")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCourses([FromBody] CourseSearchRequest request)
        {
            var students = await _courseService.SearchCourseAsync(request);
            return Ok(new ResponseModel { Status = "success", Message = "", Data = students });
        }

        [Route("GetApplications")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetApplications()
        {
            var data = await _studentService.GetApplications();
            return Ok(new ResponseModel { Status = "success", Message = "" });
        }
    }
}
