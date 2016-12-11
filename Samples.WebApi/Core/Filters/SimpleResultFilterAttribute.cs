using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Samples.WebApi.Core.Filters
{
    public class SimpleResultFilterAttribute : Attribute, IResultFilter
    {
        private readonly ILogger<SimpleResultFilterAttribute> logger;

        public SimpleResultFilterAttribute(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<SimpleResultFilterAttribute>();
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            logger.LogInformation("ResultFilter Executd!");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            logger.LogInformation("ResultFilter Executing!");
        }
    }
}