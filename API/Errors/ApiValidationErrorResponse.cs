namespace API.Errors
{
    public class ApiValidationErrorResponse : ApiErrorResponse
    {
        public ApiValidationErrorResponse() : base((int)StatusCodes.Status400BadRequest)
        {
        }
        public IEnumerable<string> Errors { get; set; }
    }
}