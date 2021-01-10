using System;
using System.IO;
using System.Linq;
using Core.Enums;
using Core.Environment.OperatingSystemInfoImpl;
using Core.Parser.Arguments;

namespace lsSpecialFolders
{
    internal static class Program
    {
        private static void Main(string[] args)
        {

            var parser = new OptionParser<Options>();
            if (!parser.TryParse(args, out var options))
                return;

            // done. options are parsed and valid. 
            // --help and --version is also already handled. :)

       
            try
            {
                // do your critical task here
                Execute(options);
            }
            catch (Exception)
            {
                // the parser instance provides a possibility to 
                // write the usage at a later program stage if needed
                parser.WriteUsage();
            }

           
        }

        private static void Execute(Options options)
        {
            var osInfo = new OperatingSystemInfo();
            Console.WriteLine($"OS: {osInfo}");
            
            Console.WriteLine();
            Console.WriteLine("------------------------");
            Console.WriteLine("Environment.GetFolderPath(SpecialFolder)");
            Console.WriteLine("------------------------");
            
            var enumValues = EnumUtil.List<Environment.SpecialFolder>()
                                     .OrderBy(i => i.Name)
                                     .ToArray();
            
            var maxLength = enumValues.Max(i=>i.Name.Length);

            var colors     = new[] {ConsoleColor.White, ConsoleColor.DarkGray};
            var colorIndex = 0;

            foreach (var itm in enumValues)
            {
                var itmValue = Environment.GetFolderPath(itm.Value);
                if (options.SkipEmpty && string.IsNullOrWhiteSpace(itmValue)) continue;
                if (options.UseColors) Console.ForegroundColor = colors[colorIndex++ % 2];
                Console.Write($"{itm.Name}".PadRight(maxLength));
                Console.WriteLine($" = {itmValue}");
            }
            Console.ResetColor();
            
            Console.WriteLine("------------------------");
            Console.WriteLine("Path.GetTempPath()");
            Console.WriteLine("------------------------");

            var tempPath = Path.GetTempPath();
            Console.WriteLine($"TempPath = {tempPath}");
            
            Console.WriteLine("------------------------");
            Console.WriteLine("Path.GetTempFileName()");
            Console.WriteLine("------------------------");
            
            var tempFileName = Path.GetTempFileName();
            Console.WriteLine($"TempFileName = {tempFileName}");
        }
    }
}
