using System.Collections.Generic;

namespace Api.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse(int status, IDictionary<string, string[]> errors) : base(status)
        {
            Errors = errors;
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}
