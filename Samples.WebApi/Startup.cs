using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Samples.WebApi.Core.Filters;
using Samples.WebApi.Core.Middlewares;

namespace Samples.WebApi
{
    public class Startup
    {


        public void ConfigureServices(IServiceCollection services)
        {
            //注入 Mvc 框架
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(SimpleActionFilterAttribute));
                options.Filters.Add(typeof(SimpleExceptionFilterAttribute));
                options.Filters.Add(typeof(SimpleResourceFilterAttribute));
                options.Filters.Add(typeof(SimpleResultFilterAttribute));

            });
        }
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            // // 添加日志支持
            loggerFactory.WithFilter(new FilterLoggerSettings()
             {
                 { "Microsoft", LogLevel.Warning }
             })
             .AddConsole().AddDebug();

            // loggerFactory.AddConsole();
            // loggerFactory.AddDebug();

            // // 添加NLog日志支持
            // loggerFactory.AddNLog();
            // //设置日志最小输出级别为Error
            // loggerFactory.WithFilter(new FilterLoggerSettings()
            //   {
            //       // 设置以命名空间开头的日志的最小输出级别
            //       { "Microsoft", LogLevel.Warning },
            //      { "Samples", LogLevel.Error }
            //  }).AddConsole();
            app.UseVisitLogger();
            // app.Run(async context =>
            // {
            //     await context.Response.WriteAsync("Hello World!");
            // });
            //添加中间件
            app.UseMvc();
        }
    }
}