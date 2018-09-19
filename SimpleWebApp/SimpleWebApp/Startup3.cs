using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using static SimpleWebApp.Counting;

namespace SimpleWebApp
{
    // Здесь мы разберемся с жизненным циклом middleware и рассмотрим основы маршрутизации
    public class Startup3
    {
        IConfiguration configuration;
        public void ConfigureServices(IServiceCollection services)
        {
            #region Session
            //services.AddDistributedMemoryCache();
            //services.AddSession();
            #endregion

            #region Custom services
            //services.AddTransient<IMyService, MyService1>();

            //services.AddSingleton<ICounter, RandomCounter>();
            //services.AddSingleton<CounterService>();
            #endregion

            #region Configuration
            //var builder = new ConfigurationBuilder()
            //    .AddInMemoryCollection(new Dictionary<string, string> {
            //    { "text2", "Hello!"}
            //})
            //    .AddMySource();
            //configuration = builder.Build();
            #endregion

            #region Routing
            //services.AddRouting();
            #endregion
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            #region Middleware
            // app.UseMiddleware<MyMiddleware>();
            // app.UseMyMiddleware();
            // app.UseMyMiddlewareWithParam("My master");
            // app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from Startup");
            //});
            #endregion

            #region StaticFiles
            //app.UseFileServer();
            //app.UseDirectoryBrowser();
            //app.UseDefaultFiles(CreateOptions());
            //app.UseStaticFiles();       
            #endregion

            #region Logging
            //loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            //loggerFactory.AddConsole();
            //var logger = loggerFactory.CreateLogger("FileLogger");
            //app.Run(async (context) =>
            //{                
            //    logger.LogInformation("Logging processing request {0}", context.Request.Path);
            //    await context.Response.WriteAsync("Hello World!");
            //});
            #endregion

            #region Cookies&Sessions
            //app.Use(async (context, next) =>
            //{
            //    context.Items["text"] = "Hello!";                
            //    await next.Invoke();
            //});

            //app.Run(async context =>
            //{
            //    var text = context.Items["text"];
            //    await context.Response.WriteAsync(text + " World!");
            //});

            //app.Run(async (context) =>
            //{
            //    if (context.Request.Cookies.ContainsKey("text"))
            //    {
            //        string text = context.Request.Cookies["text"];
            //        await context.Response.WriteAsync(text);
            //    }
            //    else
            //    {
            //        context.Response.Cookies.Append("text", "Hello World!");
            //        await context.Response.WriteAsync("No text");
            //    }
            //});

            //app.UseSession();
            //app.Run(async (context) =>
            //{
            //    if (context.Session.Keys.Contains("text"))
            //        await context.Response.WriteAsync(context.Session.GetString("text"));
            //    else
            //    {
            //        context.Session.SetString("text", "Hello World!");
            //        await context.Response.WriteAsync("No text");
            //    }
            //});
            #endregion

            #region Services
            //app.Run(async context =>
            //{
            //    IMyService myService = context.RequestServices.GetService<IMyService>();
            //    await context.Response.WriteAsync(myService.GetText());
            //});

            //app.UseMiddleware<CounterMiddleware>();
            #endregion

            #region Configuration
            //app.Run(async context =>
            //{
            //    var text = configuration["text2"];
            //    await context.Response.WriteAsync(text);
            //});
            #endregion

            #region Routing
            //var myRouteHandler = new RouteHandler(Handle);
            //var routeBuilder = new RouteBuilder(app, myRouteHandler);
            //routeBuilder.MapRoute("default", "{controller}/{action}");
            //routeBuilder.MapRoute("default2", "{controller=Home}/{action=Index}/{id}");
            //app.UseRouter(routeBuilder.Build());
            #endregion

            #region Status Code passing
            //app.UseMiddleware<ErrorHadlingMiddleware>();
            //app.UseMiddleware<AccessMiddleware>();
            #endregion
        }

        public async Task Handle(HttpContext context)
        {
            var routeValues = context.GetRouteData().Values;
            var controller = routeValues["controller"].ToString();
            var action = routeValues["action"].ToString();
            var id = routeValues["id"]?.ToString();
            await context.Response.WriteAsync($"Controller: {controller}\nAction: {action}\nID:{id}");
        }
        private DefaultFilesOptions CreateOptions()
        {
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Add("main.html");
            return options;
        }
    }
}
