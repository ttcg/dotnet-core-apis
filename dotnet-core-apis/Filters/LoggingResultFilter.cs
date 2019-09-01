using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_core_apis.Filters
{

    public class LoggingResultFilter : IResultFilter
    {
        private ILogger _logger;
        public LoggingResultFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<LoggingResultFilter>();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            {
                var controller = ((Microsoft.AspNetCore.Mvc.ControllerBase)context.Controller).ControllerContext;
                _logger.LogInformation("{controller} | {action} | {result}",
                    controller.ActionDescriptor.ControllerName,
                    controller.ActionDescriptor.ActionName,
                    GetResult(context.Result));
            }

            string GetResult(IActionResult result)
            {
                if (result is ObjectResult)
                    return JsonConvert.SerializeObject(((ObjectResult)context.Result).Value);
                
                return result.ToString();
                //return string.Empty;
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {

        }
    }
}
