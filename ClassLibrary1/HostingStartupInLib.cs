using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
[assembly: HostingStartup(typeof(ClassLibrary1.HostingStartupInLib))]
namespace ClassLibrary1
{
    public class HostingStartupInLib : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            Debug.WriteLine("Lib程序中HostingStartupInLib类启动");

            //添加配置
            builder.ConfigureAppConfiguration((context, config) => {
                var datas = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("ServiceName", "HostStartupLib")
                };
                config.AddInMemoryCollection(datas);
            });

            //添加ConfigureServices
            //builder.ConfigureServices(services => {
            //    services.AddScoped(provider => new PersonDto { Id = 2, Name = "er念之间", Age = 19 });
            //});

            //添加Configure
            builder.Configure(app => {
                app.Use(async (context, next) =>
                {
                    await next();
                });
            });

        }
    }
}
