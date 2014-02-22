using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractZips
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var argumentParser = new ArgumentParser(args);

                if (!argumentParser.Success)
                {
                    ShowHelpMessage();
                    return;
                }

                var extractManager = new ExtractManager();

                string source = argumentParser.SourceDir;
                extractManager.SourceDir = source;

                string target = argumentParser.TargetDir;
                extractManager.TargetDir = target;

                extractManager.Extract();

                Console.WriteLine("Finished");
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.ToString());
            }
        }

        private static void ShowHelpMessage()
        {
            Console.WriteLine("");
            Console.WriteLine("ExtractZips will extract given folders' zip files to target directory.");
            Console.WriteLine("ExtractZips <sourcedir> <targetdir>");
            Console.WriteLine();
        }
    }
}
