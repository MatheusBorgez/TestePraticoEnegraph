using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestePratico3
{
    class Program
    {
        static void Main(string[] args)
        {
            var diretorio = new DirectoryInfo("C:\\WorkMatheus\\TestePratico\\TestePratico3");

            var files = diretorio.GetFiles();

            Console.WriteLine($"{files.OrderByDescending(file => file.CreationTime).First().Name}");
        }
    }
}
