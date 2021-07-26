using Microsoft.AspNetCore.Mvc;
using Infrastructure.CommonTypes.Abstractions;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        protected IActionResult ReturnResponse<T>(IDataResponse<T> response)
        {
            if (response.IsError)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        protected IActionResult ReturnResponse(IDataResponse response)
        {
            if (response.IsError)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}