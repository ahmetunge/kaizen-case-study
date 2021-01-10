using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Kaizen.Blog.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data) : base(data, true)
        {
        }

        public SuccessDataResult(T data, HttpStatusCode statusCode) : base(data, true, statusCode)
        {
        }

        public SuccessDataResult(T data, string message, HttpStatusCode statusCode) : base(data, true, message, statusCode)
        {
        }

        public SuccessDataResult(string message, HttpStatusCode statusCode) : base(default, true, message, statusCode)
        {

        }
        public SuccessDataResult() : base(default, true)
        {

        }
    }
}
