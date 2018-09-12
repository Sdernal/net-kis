using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SimpleWebApp
{
    // Это основной класс, из которого запускается сервер
    public class Program
    {
        public static void Main(string[] args)
        {
            // Для запуска нам небходимо создать объект IWebHost и запускается методом Run()
            BuildWebHost(args).Run();
            //CreateWebHostManualy(args).Run();
        }

        // По-умолчанию Visual Studio конфигурирует сервер следующим образом
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args) 
                .UseStartup<Startup>() // В классе Startup находится логика обработки запросов
                .Build();

        // Но никто не мешает нам самим сконфигурировать IWebHost
        public static IWebHost CreateWebHostManualy(string[] args)
        {
            return new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
        }

        // Для первого раза достачно с этого файла, переходим в Startup.cs 
    }
}
