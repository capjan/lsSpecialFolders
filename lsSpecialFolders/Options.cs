using System;
using System.Collections.Generic;
using System.Text;
using Core.Parser.Arguments;

namespace lsSpecialFolders
{
    
    public class Options: CliOptions
    {
        [Option("c|colors", "use color for tables")]
        public bool UseColors { get; set; }

        [Option("s|skip-empty", "skip entries with no value")]
        public bool SkipEmpty { get; set; }
    }
}
