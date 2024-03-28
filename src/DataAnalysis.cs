using System;
using System.Collections.Generic;
using System.Linq;

namespace parseXmlFiles
{
    /// <summary>
    /// Provides methods for analyzing and summarizing data from LabConfig XML files.
    /// </summary>
    public static class DataAnalysis
    {
        /// <summary>
        /// Calculates the sum of domains, collectors, and filers from all parsed labConfig.xml files.
        /// </summary>
        /// /// <param name="labConfigDatasList">A list of LabConfigData objects.</param>
        /// <returns>A tuple containing the sum of domains, collectors, and filers.</returns>
        public static (int domainSum, int CollectorSum, int filerSum) GetSummary(List<LabConfigData> labConfigDatasList)
        {
            int domainSum = labConfigDatasList.Sum(item => item.DomainCount);
            int collectorSum = labConfigDatasList.Sum(item => item.CollectorCount);
            int filerSum = labConfigDatasList.Sum(item => item.FilerCount);

            return (domainSum, collectorSum, filerSum);
        }
    }
}
