using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleWebApp
{
    // Здесь мы разберемся с жизненным циклом middleware и рассмотрим основы маршрутизации
    public class Startup3
    {

        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<MyMiddleware>();
            app.UseMyMiddleware();
            app.UseMyMiddlewareWithParam("My master");
            app.Run(async context =>
           {
               await context.Response.WriteAsync("Hello from Startup");
           });
        }
    }
}
