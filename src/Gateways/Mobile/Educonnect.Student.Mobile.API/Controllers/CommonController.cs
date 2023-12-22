using Educonnect.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Educonnect.Student.Mobile.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonService _commonService;
        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }
        [Route("lookupdata")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(AllLookupDataResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetLookupDataAsync()
        {
            var data = await _commonService.GetAllLookupDataAsync();
            return Ok(new ResponseModel { Status = "success", Message = "", Data = data });
        }
    }
}
