using System;
using System.Collections.Generic;

namespace parseXmlFiles
{
    public class DataPrinter : IDataPrinter
    {
        /// <summary>
        /// Prints the data extracted from the XML files to the console.
        /// </summary>
        /// /// <param name="labConfigDatasList">A list of LabConfigData objects.</param>
        public void PrintData(List<LabConfigData> labConfigDatasList)
        {
            Console.WriteLine("{0, -100} {1, -15} {2, -15} {3, -15} {4}", "Path", "Domain", "Collector", "Filer", "Domain names");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (var config in labConfigDatasList)
            {
                string domainNames = String.Join(", ", config.DomainNames);
                Console.WriteLine("{0, -100} {1, -15} {2, -15} {3, -15} {4}", config.Path, config.DomainCount, config.CollectorCount, config.FilerCount, domainNames);
            }

            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            var (domainSum, CollectorSum, filerSum) = DataAnalysis.GetSummary(labConfigDatasList);
            Console.WriteLine("{0, -100} {1, -15} {2, -15} {3, -15}", "Total:", domainSum, CollectorSum, filerSum);
        }
    }
}
