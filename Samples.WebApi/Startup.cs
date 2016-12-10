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
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();
            //添加中间件
            app.UseMvc();
        }
    }
}