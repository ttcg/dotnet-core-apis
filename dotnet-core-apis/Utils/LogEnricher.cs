using Serilog.Core;
using Serilog.Events;
using System;

namespace dotnet_core_apis.Utils
{
    public class LogEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent le, ILogEventPropertyFactory lepf)
        {           
            // Remove unwanted properties
            le.RemovePropertyIfPresent("SourceContext");
            le.RemovePropertyIfPresent("RequestId");
            //le.RemovePropertyIfPresent("RequestPath");
            le.RemovePropertyIfPresent("ActionId");
            le.RemovePropertyIfPresent("ConnectionId");
            le.RemovePropertyIfPresent("CorrelationId");
            le.RemovePropertyIfPresent("ActionName");

            // add additional properties
            le.AddPropertyIfAbsent(lepf.CreateProperty("machineName", Environment.MachineName));
            le.AddPropertyIfAbsent(lepf.CreateProperty("application", "DotNetCoreApis"));
            le.AddPropertyIfAbsent(lepf.CreateProperty("environment", Helpers.GetEnvironmentName()));
            le.AddPropertyIfAbsent(lepf.CreateProperty("version", Helpers.GetVersion()));
        }
    }
}
