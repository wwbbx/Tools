using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyTddMovies
{
    class Program
    {
        static bool doIt = false;

        static void Main(string[] args)
        {
            try
            {
                if(!IsArgumentCorrect(args))
                {
                    ShowHelpMessage();
                    return;
                }

                var copyer = new MovieCopy();

                var rootDir = @"C:\TDDownload";
                var targetDir = @"C:\Movies";

                copyer.DoIt = doIt;

                copyer.Copy(rootDir, targetDir);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
            }
        }

        private static void ShowHelpMessage()
        {
            Console.WriteLine("Copy Thunder downloaded movies to specified folder.");
            Console.WriteLine("Please make sure Thunder is turned off.");
            Console.WriteLine("Default source directory is C:\\TDDownload");
            Console.WriteLine("Default output directory is C:\\Movies.");
            Console.WriteLine("Default behavior will not copy it.");
            Console.WriteLine("Specify '-doit' will let real copy happens.");
        }

        private static bool IsArgumentCorrect(string[] args)
        {
            if(args.Length > 0)
            {
                if (args[0] == "-help") return false;

                if (args[0] == "-doit") doIt = true;

                return true;
            }

            return true;
        }
    }
}
