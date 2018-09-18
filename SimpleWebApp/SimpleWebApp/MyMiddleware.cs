using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebApp
{
    public class MyMiddleware
    {
        RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("Hello from my middleware\n");
            await _next.Invoke(context);
        }
    }

    public class MyMiddlewareWithParam
    {
        RequestDelegate _next;
        string _userName;

        public MyMiddlewareWithParam(RequestDelegate next, string userName)
        {
            _next = next;
            _userName = userName;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync($"Hello, {_userName}, from my middleware with param\n");
            await _next.Invoke(context);
        }
    }

    public static class MyExtensions
    {
        public static IApplicationBuilder UseMyMiddleware( this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }

        public static IApplicationBuilder UseMyMiddlewareWithParam( this IApplicationBuilder builder, string userName)
        {
            return builder.UseMiddleware<MyMiddlewareWithParam>(userName);
        }
    }
}
