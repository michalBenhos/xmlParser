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
            string path = @".\ParseXML";
            var xmlParser = new XMLParser();
            xmlParser.ParseDirectory(path);
            xmlParser.PrintData();
        }
    }
}