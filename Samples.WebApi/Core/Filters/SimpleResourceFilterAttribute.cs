using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Samples.WebApi.Core.Filters
{
    public class SimpleResourceFilterAttribute : Attribute, IResourceFilter
    {
        private readonly ILogger<SimpleResourceFilterAttribute> logger;

        public SimpleResourceFilterAttribute(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<SimpleResourceFilterAttribute>();
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            logger.LogInformation("ResourceFilter Executed!");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            logger.LogInformation("ResourceFilter Executing!");
        }
    }
}
