using System.Xml.Linq;

namespace parseXmlFiles
{
    /// <summary>
    /// Parses 'labConfig.xml' files from a specified directory and its subdirectories, 
    /// extracting data into <see cref="LabConfigData"/> objects.
    /// </summary>
    public class XMLParser
    {
        /// <summary>
        /// Parses all the 'labConfig.xml' files in the specified directory and subdirectories.
        /// </summary>
        /// <param name="directoryPath">The path to the root directory containing the labConfig.xml files.</param>
        /// <returns>A List of <see cref="LabConfigData"/> containing the extracted data from all 'labConfig.xml' files.</returns>
        public static List<LabConfigData> ParseDirectory(string directoryPath)
        {
            List<LabConfigData> LabConfigDatasList = new();
            try
            {
                var files = Directory.GetFiles(directoryPath, "labConfig.xml", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    try
                    {
                        LabConfigDatasList.Add(ParseFile(file));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error parsing file {file} : {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing files in {directoryPath} : {ex.Message}");
            }

            return LabConfigDatasList;
        }

        /// <summary>
        /// Parses a single 'labConfig.xml' file and extracts its data into a <see cref="LabConfigData"/> object.
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
                                                        .Where(n => n != null)
                                                        .Select(n => n.Value)
                                                        .ToList()
            };

            return fileData;
        }
    }
}