using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("errors/{code}")]
    public class ErrorsController : ControllerBase
    {
        [HttpGet]
        public ActionResult Error(int code)=> new ObjectResult(new ApiErrorResponse(code));
    }
}