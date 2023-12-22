using Educonnect.Core.Models;

namespace Educonnect.Student.Mobile.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormService _formService;
        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        [Route("LeadQualification")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetLeadQualificationDataAsync()
        {
            var data = await _formService.GetAllLeadDataAsync();
            return Ok(new ResponseModel { Status = "success", Message = "", Data = data });
        }
    }
}
