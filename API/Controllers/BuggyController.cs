
using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  
    public class BuggyController : BaseApiController
    {
        [HttpGet("not_found")]
        public ActionResult GetNotFoundRequest()=> NotFound(new ApiErrorResponse(404));
        [HttpGet("server_error")]
        public ActionResult GetServerError()
        {
            var value="asd";
            var intValue=int.Parse(value);
            return Ok();
        }
        [HttpGet("bad_request")]
        public ActionResult GetBadRequest()=>BadRequest(new ApiErrorResponse(400));
        [HttpGet("bad_request/{id}")]
        public ActionResult GetNotFoundBadRequest(int id)=>Ok();

    }
}