namespace API.Errors
{
    public class ApiErrorResponse
    {
        public ApiErrorResponse(int statusCode,string message=null) 
        {
            StatusCode = statusCode;
            Message=message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400=> "A bad request, you have made",
                401=>"Authorized, you are not",
                404=> "Resource found, it was not",
                500=> "Internal server error!",
                _=>""
            };
        }

        public int StatusCode { get;}
        public string Message { get; }
    }
}