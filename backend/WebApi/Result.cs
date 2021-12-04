using System.Net;

namespace WebApi
{
   public class Result
    {
        private Result(bool succeeded, IEnumerable<string>? errors, string? message, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
        {
            Succeeded = succeeded;
            Errors = errors?.ToArray();
            Message = message;
            Timestamp = DateTime.Now;
            HttpStatusCode = httpStatusCode;
        }

        private bool Succeeded { get; set; }

        private string? Message { get; set; }

        private string[]? Errors { get; set; }
        
        private DateTime Timestamp { get; set; }


        private HttpStatusCode HttpStatusCode { get; set; }

        public static Result Success(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new Result(true, null, null,statusCode);
        }

        public static Result Success(string? message)
        {
            return new Result(true, null, message);
        }

        public static Result Failure(IEnumerable<string> errors)
        {
            var enumerable = errors as string[] ?? errors.ToArray();

            return new Result(false, enumerable, enumerable?.FirstOrDefault());
        }
        

      
    }
}