namespace parseXmlFiles
{
    /// <summary>
    /// Provides an abstraction for outputting parsed XML data. 
    /// This interface allows for different implementations of data presentation.
    /// </summary>
    public interface IDataPrinter
    {
        /// <summary>
        /// Prints the data extracted from the XML files to the console.
        /// </summary>
        /// <param name="labConfigDatasList">A list of LabConfigData objects.</param>
        void PrintData(List<LabConfigData> labConfigDatasList);
    }
}
