using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Subscriptions.Application.Common.Exceptions;

namespace Subscriptions.Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ExceptionHandlerMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception e)
            {
                var result = string.Empty;
                var code = HttpStatusCode.InternalServerError;
                if (e is ValidationException validationException)
                {
                    code = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.Failures);
                }

                if (e is BadRequestException)
                {
                    code = HttpStatusCode.BadRequest;
                }

                if (e is NotAuthorizedException)
                {
                    code = HttpStatusCode.Unauthorized;
                }
                if (e is NotFoundException)
                {
                    code = HttpStatusCode.NotFound;
                }
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) code;
                if (result ==  string.Empty)
                {
                    result = JsonConvert.SerializeObject(new {Error = e.Message});
                }
                await context.Response.WriteAsync(result);
                throw;
            }
        }
    }

    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static void UseExceptionHandlerMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}