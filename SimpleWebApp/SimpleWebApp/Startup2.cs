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
    public class Startup2
    {

        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            int a = 2;
            app.Run(async (context) =>
           {
               a *= 2;
               await context.Response.WriteAsync($"Result: {a}");
           });
            // Далее обновим страницу несколько раз
            #region Что же произошло?
            // Метод Configure выполняется один раз при создании объекта класса Startup
            // и все компоненты создаются один раз
            // т.е. поэтому при повторных запросах счетчик продолжает увеличиваться
            // а хром вообще делает по 2 запроса за раз
            #endregion

            // Далее рассмотрим основы маршрутизации
            // Они представленны методами Run и RunWhen
            app.Map("/home", apphome => {
                // Можно делать вложенные Map
                apphome.Map("/index", appindex => appindex.Run(async (context) =>
                {
                    await context.Response.WriteAsync($"INDEX");
                }));
                apphome.Run(async (context) =>
                {
                    await context.Response.WriteAsync($"HOME");
                });
            });
           

            app.MapWhen(context =>
            {
                // Проверяем, есть ли в запросе параметр id
                return context.Request.Query.ContainsKey("id");
            },
            appid => appid.Run(async context =>
            {
                // И выводим его 
                string id = context.Request.Query["id"];
                await context.Response.WriteAsync($"ID: {id}");
            }));

            // Наверное больно смотреть на вложенные лямда-функции
            // Можно всегда вынести в отдельный метод =)
            app.Map("/about", About);

            // На этом первое знакомство с ASP.Net Core можно считать завершенным!
        }

        private static void About(IApplicationBuilder app)
        {
            app.Run(async context =>
           {
               await context.Response.WriteAsync("ABOUT");
           });
        }
    }
}
