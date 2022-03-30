using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RoomService.WebAPI
{
    public class PasswordCheckerMiddleware
    {
        private readonly RequestDelegate _next;
       
        public PasswordCheckerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            const string passwordHeader = "passwordKey";
            const string defaultPassword = "passwordKey123456789000";
            var expectedPassword = Environment.GetEnvironmentVariable(passwordHeader) ?? defaultPassword;
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            if (context.Request.Headers.ContainsKey(passwordHeader))
            {
                var passed = string.Equals(context.Request.Headers[passwordHeader], expectedPassword, StringComparison.InvariantCulture);
                if (passed)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    await _next.Invoke(context);
                }
            }
        }
    }
}
