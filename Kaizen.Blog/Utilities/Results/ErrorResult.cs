using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Kaizen.Blog.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(false)
        {
        }

        public ErrorResult(string message, HttpStatusCode statusCode) : base(false, message, statusCode)
        {
        }

        public override string ToString()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                
            };

            return JsonSerializer.Serialize(this, options);
        }
    }
}
