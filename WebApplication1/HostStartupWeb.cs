using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//通过HostingStartup指定要启动的类型
[assembly: HostingStartup(typeof(WebApplication1.HostingStartupInWeb))]
namespace WebApplication1
{
    public class HostingStartupInWeb : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //程序启动时打印依据话，代表执行到了这里
            Debug.WriteLine("Web程序中HostingStartupInWeb类启动");

            //可以添加配置
            builder.ConfigureAppConfiguration(config => {
                //模拟添加一个一个内存配置
                var datas = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("ServiceName", "HostStartupWeb")
                };
                config.AddInMemoryCollection(datas);
            });

            //可以添加ConfigureServices
            //builder.ConfigureServices(services => {
            //    //模拟注册一个PersonDto
            //    services.AddScoped(provider => new PersonDto { Id = 1, Name = "yi念之间", Age = 18 });
            //});

            //可以添加Configure
            builder.Configure(app => {
                //模拟添加一个中间件
                app.Use(async (context, next) =>
                {
                    await next();
                });
            });
        }
    }
}