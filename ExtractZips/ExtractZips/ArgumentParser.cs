using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExtractZips
{
    class ArgumentParser
    {
        private string[] args;

        public ArgumentParser(string[] args)
        {
            this.args = args;

            this.Success = false;

            if (args.Length != 2) return;

            SourceDir = args[0];
            TargetDir = args[1];

            if (!Directory.Exists(SourceDir)) return;

            if (!string.IsNullOrEmpty(SourceDir) && !string.IsNullOrEmpty(TargetDir))
            {
                this.Success = true;
            }
        }

        public bool Success { get; set; }

        public string SourceDir { get; set; }

        public string TargetDir { get; set; }
    }
}
