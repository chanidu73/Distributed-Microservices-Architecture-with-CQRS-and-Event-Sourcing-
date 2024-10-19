using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace UserService.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next ;
        public ExceptionHandlerMiddleware(RequestDelegate request)
        {
            _next = request;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try {
                await _next(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(context , ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}