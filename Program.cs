using System;

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
        static void Main(string[] args)
        {
            string path = @"C:\Users\Infinity\Desktop\michal\xmlParser";
            var xmlParser = new XMLParser();
            xmlParser.ParseDirectory(path);
            xmlParser.PrintData();
        }
    }
}