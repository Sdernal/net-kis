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
    // Этот класс собственно отвечает за обработку запросов
    public class Startup
    {
        // Здесь добавляются сервисы, пока не трогаем
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // Здесь как раз происходит конфиuурация конвейера обработки запроса
        public void Configure(IApplicationBuilder app)
        {
            // Первым делом напишем Hello World!
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

            // Далее явно передадим делегат            
            RequestDelegate handle = Handle;
            app.Run(handle);
            
            #region Не работает?
            // А что если закомментировать предыдущий Run?
            // Запомни: Run - терминальный элемент в конвейере 
            #endregion

            // Теперь поиграемся с конвейером 
            // Для этого добавим два элемента элемента в конвейер
            // Что выведется в браузере?
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello");
                await next.Invoke();
                await context.Response.WriteAsync("World!");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(" pipeline ");
            });

            // Чтобы понять, что произошло, посмотри схему конвейера в презенташке =)
            // А теперь перейдем в Startup2.cs и не забудь поменять конфигурацию веб-хоста
        }
       
        public async Task Handle(HttpContext context)
        {
            await context.Response.WriteAsync("Hello from Handle");
        }
    }
}
