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
        static void Main()
        {
            string path = @"ParseXML";
            List<LabConfigData> labConfigDatas = XMLParser.ParseDirectory(path);
            DataPrinter dataPrinter = new();
            dataPrinter.PrintData(labConfigDatas);
        }
    }
}