using System;
using System.Collections.Generic;

namespace parseXmlFiles
{
    /// <summary>
    /// Represents the data extracted from a LabConfig XML file.
    /// </summary>
    public class LabConfigData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LabConfigData"/> class with a specified file path.
        /// </summary>
        /// <param name="path">The file path of the labConfig XML file.</param>
        /// <exception cref="ArgumentNullException">Thrown when the path is null.</exception>
        public LabConfigData(string path)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path), "Path cannot be null");
            DomainNames = new();
        }
        public string Path { get; set; }
        public int DomainCount { get; set; }
        public int FilerCount { get; set; }
        public int CollectorCount { get; set; }
        public List<string> DomainNames { get; set; }
    }
}