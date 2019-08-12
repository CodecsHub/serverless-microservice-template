using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ServerlessMicroservice.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ServerlessMicroservice.API.Helpers
{

    // @title:  Custom Global Error Trapping
    // @todo: add dynamic language translator
    // @todo: dont use direct text return in the functions, define magic methods
    // @see: <root> startup.cs

    /// <summary>
    ///
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerFactory _logger;
        /// <summary>
        ///
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _logger = logger;
            _next = next;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            var logger = _logger.CreateLogger<ExceptionMiddleware>();
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new BaseContracts()
            {
                Code = context.Response.StatusCode,
                //Message = "Internal Server Error from the custom middleware."
                Message = exception.Message
            }.ToString());
        }
    }
}
