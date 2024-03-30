using System;
using System.Collections.Generic;

namespace parseXmlFiles
{
    /// <summary>
    /// Implements the <see cref="IDataPrinter"/> interface to provide functionality for printing
    /// data extracted from 'labConfig.xml' files to the console.
    /// </summary>
    public class DataPrinter : IDataPrinter
    {
        /// <summary>
        /// Prints the data extracted from the XML files to the console.
        /// </summary>
        /// <param name="labConfigDatasList">A list of LabConfigData objects.</param>
        public void PrintData(List<LabConfigData> labConfigDatasList)
        {
            Console.WriteLine("{0, -80} {1, -15} {2, -15} {3, -15} {4}", 
                    "Path", "Domain", "Collector", "Filer", "Domain names");
            Console.WriteLine(new string('-', 150));

            foreach (var labConfig in labConfigDatasList)
            {
                string domainNames = String.Join(", ", labConfig.DomainNames);
                Console.WriteLine("{0, -80} {1, -15} {2, -15} {3, -15} {4}",
                    labConfig.Path, labConfig.DomainCount, labConfig.CollectorCount, labConfig.FilerCount, domainNames);
            }

            Console.WriteLine(new string('-', 150));

            var (domainSum, CollectorSum, filerSum) = DataAnalysis.GetSummary(labConfigDatasList);
            Console.WriteLine("{0, -80} {1, -15} {2, -15} {3, -15}", 
                            "Total:", domainSum, CollectorSum, filerSum);
        }
    }
}
