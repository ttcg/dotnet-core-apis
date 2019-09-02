using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            {       
                var controller = ((ControllerBase)context.Controller).ControllerContext;

                _logger.LogInformation("{method} | {controller} | {action} | {result} | {model}",
                    controller.HttpContext.Request.Method,
                    controller.ActionDescriptor.ControllerName,
                    controller.ActionDescriptor.ActionName,                    
                    GetResult(context.Result),
                    GetModel(controller.HttpContext.Request.Body)
                );
            }

            string GetModel(Stream stream)
            {
                if (stream is Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream)
                {
                    var model = string.Empty;
                    stream.Position = 0;
                    using (var reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        model = reader.ReadToEnd();
                        return model;
                    }
                }

                return null;
            }

            string GetResult(IActionResult result)
            {
                if (result is ObjectResult)
                    return JsonConvert.SerializeObject(((ObjectResult)context.Result).Value);

                return GetResultName(result);
            }

            string GetResultName(IActionResult result) => result.ToString().Split('.').LastOrDefault();
        }
    }
}
