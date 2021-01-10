using FluentValidation;
using Kaizen.Blog.Utilities.Messages;
using Kaizen.Blog.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kaizen.Blog.Middlewares
{
    public class ErrorHandlingMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {

            _logger.Error("Intervalserver Error : ",JsonConvert.SerializeObject(ex));

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = ErrorMessages.InternalServerError;
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            if (ex.GetType() == typeof(ValidationException))
            {
                message = "";
                var exception = (ValidationException)ex;
                if (exception != null && exception.Errors.Count() > 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();

                    foreach (var error in exception.Errors)
                    {
                        stringBuilder.Append(error.ErrorMessage);
                    }

                    message = stringBuilder.ToString();
                }

                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                statusCode = HttpStatusCode.UnprocessableEntity;
            }
            await httpContext.Response.WriteAsync(new ErrorResult(message, statusCode).ToString());

        }
    }
}
