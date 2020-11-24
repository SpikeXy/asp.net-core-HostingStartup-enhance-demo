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

                    //ͨ��UseSetting�ķ�ʽָ�����򼯵�����

                    //ֱ�ӿ�����namespace�����ã���������ÿո�����
                    //webBuilder.UseSetting(WebHostDefaults.HostingStartupAssembliesKey, "ClassLibrary1");
                    //���HostingStartup���ڶ�������п���ʹ��;�ָ�,����HostStartupLib;HostStartupLib2

                    //webBuilder.UseSetting(WebHostDefaults.HostingStartupAssembliesKey, "HostStartupLib;HostStartupLib2");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
