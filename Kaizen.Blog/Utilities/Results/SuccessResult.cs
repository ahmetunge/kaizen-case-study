using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Kaizen.Blog.Utilities.Results
{
    public class SuccessResult : Result
    {

        public SuccessResult() : base(true)
        {
        }

        public SuccessResult(HttpStatusCode statusCode):base(true,statusCode)
        {
        }

        public SuccessResult(string message, HttpStatusCode statusCode) : base(true, message, statusCode)
        {
        }

    }
}
