using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Linq;

namespace parseXmlFiles
{
    /// <summary>
    /// Parses XML files and extracts data into <see cref="LabConfigData"/> objects.
    /// </summary>
    public class XMLParser
    {
        private List<LabConfigData> LabConfigDatasList = new();

        /// <summary>
        /// Parses all the labConfig.xml files in the specified directory and subdirectories.
        /// </summary>
        /// <param name="directoryPath">The path to the root directory containing the labConfig.xml files.</param>
        public void ParseDirectory(string directoryPath)
        {
            var files = Directory.GetFiles(directoryPath, "labConfig.xml", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                LabConfigDatasList.Add(ParseFile(file));
            }
        }

        /// <summary>
        /// Parses a single labConfig.xml file and extracts its data into a <see cref="LabConfigData"/> object.
        /// </summary>
        /// <param name="path">The file path to the labConfig.xml file.</param>
        /// <returns>A new <see cref="LabConfigData"/> object containing the extracted data.</returns>
        private static LabConfigData ParseFile(string path)
        {
            XDocument doc = XDocument.Load(path);
            LabConfigData fileData = new(path)
            {
                DomainCount = doc.Descendants("domain").Count(),
                CollectorCount = doc.Descendants("collector").Count(),
                FilerCount = doc.Descendants("filer").Count(),
                DomainNames = doc.Descendants("domain").Select(d => d.Element("name"))
                                                        .Where(n => n != null).Select(n => n.Value).ToList()
            };

            return fileData;
        }

        /// <summary>
        /// Prints the data extracted from the XML files to the console.
        /// </summary>
        public void PrintData()
        {
            Console.WriteLine("{0, -100} {1, -15} {2, -15} {3, -15} {4}", "Path", "Domain", "Collector", "Filer", "Domain names");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (var config in LabConfigDatasList)
            {
                string domainNames = String.Join(", ", config.DomainNames);
                Console.WriteLine("{0, -100} {1, -15} {2, -15} {3, -15} {4}", config.Path, config.DomainCount, config.CollectorCount, config.FilerCount, domainNames);
            }

            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            var (domainSum, CollectorSum, filerSum) = GetSummary();
            Console.WriteLine("{0, -100} {1, -15} {2, -15} {3, -15}", "Total:", domainSum, CollectorSum, filerSum);
        }

        /// <summary>
        /// Calculates the sum of domains, collectors, and filers from all parsed labConfig.xml files.
        /// </summary>
        /// <returns>A tuple containing the sum of domains, collectors, and filers.</returns>
        private (int domainSum, int CollectorSum, int filerSum) GetSummary()
        {
            int domainSum = LabConfigDatasList.Sum(item => item.DomainCount);
            int collectorSum = LabConfigDatasList.Sum(item => item.CollectorCount);
            int filerSum = LabConfigDatasList.Sum(item => item.FilerCount);

            return (domainSum, collectorSum, filerSum);
        }
    }
}