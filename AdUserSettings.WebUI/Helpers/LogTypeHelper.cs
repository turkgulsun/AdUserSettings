using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdUserSettings.WebUI.Helpers
{
    public class LogTypeHelper
    {
        private LogTypeHelper(string value) { Value = value; }

        public string Value { get; set; }

        public static LogTypeHelper Success { get { return new LogTypeHelper("Success"); } }
        public static LogTypeHelper Info { get { return new LogTypeHelper("Info"); } }
        public static LogTypeHelper Error { get { return new LogTypeHelper("Error"); } }
    }
}
