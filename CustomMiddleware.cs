using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MiddlewareExample
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomMiddleware(RequestDelegate next)
        {
                _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            //Custome Logic
            Console.WriteLine("Custom Middleware : Request handling");

            if (!context.Request.Path.Value.Contains("/blocked"))
            {
                await _next(context);
            }
            else
            {
                context.Response.StatusCode=StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("This Request Blocked by Middleware");
            }

            Console.WriteLine("Custom Middleware : Request Finished");
        }
    }
}
