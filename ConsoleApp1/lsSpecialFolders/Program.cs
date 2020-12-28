using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Core.Diagnostics.Impl;
using Core.Enums;
using Core.Environment;
using Core.Environment.OperatingSystemInfoImpl;


namespace ConsoleApp1
{
    class Program
    {

        
        static void Main(string[] args)
        {
            var osInfo = new OperatingSystemInfo();

            
            Console.WriteLine($"OS: {osInfo}");
            
            Console.WriteLine();
            Console.WriteLine("------------------------");
            Console.WriteLine(".NET Special Folders");
            Console.WriteLine(" Got via: Environment.GetFolderPath(SpecialFolder)");
            Console.WriteLine("------------------------");
            
            var enumValues = EnumUtil.List<Environment.SpecialFolder>()
                .OrderBy(i => i.Name)
                .ToArray();
            
            var maxLength = enumValues.Max(i=>i.Name.Length);
            
            foreach (var itm in enumValues)
            {
                Console.Write($"{itm.Name}".PadLeft(maxLength));
                Console.Write(" = ");
                Console.WriteLine(Environment.GetFolderPath(itm.Value));    
            }
            
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
