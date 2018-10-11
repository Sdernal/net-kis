using System;
using System.Globalization;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CalculatorWebApp
{
    public class Startup
    {
        private static ILogger _logger;
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
            services.AddTransient<CalculatorService>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            // Добавляем логгирование в файл
            loggerFactory.AddProvider(new FileLoggerProvider(Path.Combine(Directory.GetCurrentDirectory(),"logs.txt")));
            _logger = loggerFactory.CreateLogger("FileLogger");
            
            // Используем main.html в качестве стартовой страницы
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("main.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles();
            
            // Читаем текущий результат из куки
            app.UseMiddleware<ReadCookiesMiddleware>();
            
            // Используем маршрутизацию для парсинга команд
            var actionRouteHandler = new RouteHandler(async (context) =>
            {
                var routeValues = context.GetRouteData().Values;
                var action = routeValues["action"].ToString();
                var provider = new NumberFormatInfo {NumberDecimalSeparator = "."};
                var number = Convert.ToDouble(routeValues["number"].ToString(), provider);
                if (action == "divide" && number == 0)
                {
                    _logger.LogWarning("Attempt to divide by zero!");
                    await context.Response.WriteAsync($"<h1>Cannot divide by zero.</h1>\n<h1>Result: {context.Items["result"]}</h1>");
                }
                else
                {
                    CalculatorService calculatorService = context.RequestServices.GetService<CalculatorService>();
                    switch (action)
                    {
                        case "start":
                            context.Items["result"] = number;
                            _logger.LogInformation("Start with {0}", number);
                            break;
                        case "add":
                            context.Items["result"] = calculatorService.Add((double) context.Items["result"], number);
                            _logger.LogInformation("Add {0}. Result: {1}", number, context.Items["result"]);
                            break;
                        case "subtract":
                            context.Items["result"] = calculatorService.Subtract((double) context.Items["result"], number);
                            _logger.LogInformation("Subtract {0}. Result: {1}", number, context.Items["result"]);
                            break;
                        case "multiply":
                            context.Items["result"] = calculatorService.Multiply((double) context.Items["result"], number);
                            _logger.LogInformation("Multiply by {0}. Result: {1}", number, context.Items["result"]);
                            break;
                        case "divide":
                            context.Items["result"] = calculatorService.Divide((double) context.Items["result"], number);
                            _logger.LogInformation("Divide by {0}. Result: {1}", number, context.Items["result"]);
                            break;
                    }
                    context.Response.Cookies.Append("result", context.Items["result"].ToString());
                    await context.Response.WriteAsync($"<h1>Result: {context.Items["result"]}</h1>");
                }
            });
            var routeBuilder = new RouteBuilder(app, actionRouteHandler);
            routeBuilder.MapRoute("default", 
                "{action}/{number:double}",
                null,
                new { action = new ActionConstraint() });
            app.UseRouter(routeBuilder.Build());

            app.Map("/clear", Clear);
        }
        
        private static void Clear(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                _logger.LogInformation("Clear to 0");
                context.Response.Cookies.Append("result", "0");
                await context.Response.WriteAsync("<h1>Result: 0</h1>");
            });
        }
    }
}