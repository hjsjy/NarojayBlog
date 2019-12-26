using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NarojayBlog.Core;
using Newtonsoft.Json;

namespace NarojayBlog.Webapi.Filters
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this.next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var code = HttpStatusCode.InternalServerError;
            try
            {
                await next(context);

            }
            catch (Exception ex)
            {
                if (ex is TipsException)
                {
                    code = HttpStatusCode.BadRequest;
                    if (ex.InnerException != null)
                    {
                        _logger.LogError($"异常信息: {ex.InnerException.Message}");
                    }
                }
                else
                {
                    _logger.LogError($"异常信息: {ex.Message}");

                }
                await HandleExceptionAsync(context, ex, (int)code);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex, int code)
        {
            var tes = new ExceptionResultModel(code, ex);
            var result = JsonConvert.SerializeObject(tes);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;
            return context.Response.WriteAsync(result);
        }
    }
}