using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_core_apis.Utils
{
    public class SecondLevelClass
    {
        private ILogger<SecondLevelClass> _log;

        public SecondLevelClass(ILogger<SecondLevelClass> log)
        {
            _log = log;
        }

        public void TestMethod()
        {
            _log.LogWarning("Response from Test Method from Second Level Class");
        }
    }
}
