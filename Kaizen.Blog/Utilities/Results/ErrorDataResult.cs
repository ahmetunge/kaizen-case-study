
using System.Net;

namespace Kaizen.Blog.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {

        public ErrorDataResult(T data) : base(data, false)
        {
        }

        public ErrorDataResult(T data, string message, HttpStatusCode statusCode) : base(data, false, message, statusCode)
        {
        }

        public ErrorDataResult(string message, HttpStatusCode statusCode) : base(default, false, message, statusCode)
        {

        }
        public ErrorDataResult() : base(default, false)
        {

        }

    }
}
