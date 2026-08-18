using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace ApiNegocio.Middleware
{
    public class GlobalExcepctionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExcepctionHandlingMiddleware> _logger;
        public GlobalExcepctionHandlingMiddleware(ILogger<GlobalExcepctionHandlingMiddleware> logger) => _logger = logger;
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

                ProblemDetails problem = new()
                {
                    Status=(int) HttpStatusCode.InternalServerError,
                    Type="Server error",
                    Title="Server error",
                    Detail = "Internal server error"
                };

                string join=JsonSerializer.Serialize(problem);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(join);


            }
        }
    }
}
