using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Samples.WebApi
{
    public class Startup
    {


        public void ConfigureServices(IServiceCollection services){
            //注入 Mvc 框架
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app,ILoggerFactory loggerFactory)
        {
            // loggerFactory.AddConsole();
            // loggerFactory.AddDebug();
            // //设置日志最小输出级别为Error
              loggerFactory.WithFilter(new FilterLoggerSettings()
              {
                  // 设置以命名空间开头的日志的最小输出级别
                  { "Microsoft", LogLevel.Warning },
                 { "Samples", LogLevel.Error }
             }).AddConsole();
            //添加中间件
            app.UseMvc();
        }
    }
}