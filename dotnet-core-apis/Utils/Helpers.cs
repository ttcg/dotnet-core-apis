using System.Configuration;
using System.Reflection;

namespace dotnet_core_apis.Utils
{
    public static class Helpers
    {
        public static string GetEnvironmentName()
        {
            return ConfigurationManager.AppSettings["Environment"].ToString();
        }

        public static string GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
