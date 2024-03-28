using System;
using System.Collections.Generic;
using System.IO;

namespace parseXmlFiles
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main method that starts the application.
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Enter directory path: ");
            string? path = Console.ReadLine();
            if (path != null && Directory.Exists(path))
            {
                List<LabConfigData> labConfigDatas = XMLParser.ParseDirectory(path);
                DataPrinter dataPrinter = new();
                dataPrinter.PrintData(labConfigDatas);
            }
            else
            {
                Console.WriteLine("Invalid directory path");
            }
        }
    }
}