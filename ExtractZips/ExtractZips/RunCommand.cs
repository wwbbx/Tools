using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractZips
{
    class RunCommand
    {
        public static void Execute(string program, string parameters)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(program, parameters);
            Process.Start(startInfo);
        }
    }
}
