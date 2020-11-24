using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    //通过UseSetting的方式指定程序集的名称

                    //直接可以用namespace来调用，多个就是用空格区分
                    //webBuilder.UseSetting(WebHostDefaults.HostingStartupAssembliesKey, "ClassLibrary1");
                    //如果HostingStartup存在多个程序集中可以使用;分隔,比如HostStartupLib;HostStartupLib2

                    //webBuilder.UseSetting(WebHostDefaults.HostingStartupAssembliesKey, "HostStartupLib;HostStartupLib2");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
