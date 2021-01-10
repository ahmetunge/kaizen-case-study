using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Kaizen.Blog.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
        HttpStatusCode StatusCode { get; }
    }
}
