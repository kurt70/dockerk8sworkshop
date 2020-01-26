using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiCalculatorAPI.Config
{
    public class DatabaseConfig
    {
        public string DatabaseName { get; set; }

        public string RetentionPolicyName { get; set; }

        public string RetentionString { get; set; }
    }
}
