using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03aug
{
    public static class DirectoryExplorer
    {
        public static void Print(string directoryPath, int indent = 0)
        {
            if (!Directory.Exists(directoryPath)) return;

            var indentString = string.Concat(Enumerable.Repeat("  ", indent));
            var directories = Directory.GetDirectories(directoryPath);
            var files = Directory.GetFiles(directoryPath);
            Console.WriteLine($"{indentString}{directoryPath}");
            foreach (var dir in directories)
            {
                Print(dir, indent + 2);
            }
            foreach (var file in files)
            {
                Console.WriteLine($"{indentString}{file}");
            }
        }
    }
}
