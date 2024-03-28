# XML Parser for LabConfig.xml files

## Overview

This C# console application that parses `labConfig.xml` files to extract data related to domains, collectors, and filers. 
Each file's data is represented by a `LabConfigData` object, and the application prints a summary table to the console, 
displaying the information for each file and a total summary for all files processed.

## Requirements

- Recursively scan a given directory for `LabConfig.xml` files.
- Output a table containing:
  - The file path.
  - The count of domain, collector, and filer nodes.
  - The name associated with each domain node.
- Provide a total summary for domains, collectors, and filers across all files.

### Prerequisites

- .NET 5.0 SDK or later
- Visual Studio 2019 or later (optional, for development)

### Running the Application

1. Clone the repository to your local machine.
2. Navigate to the project directory in the terminal.
3. Execute the following command to run the application:

```shell
dotnet build
dotnet run
```


### Application Structure

- LabConfigData: Represents the structured data extracted from each labConfig.xml file.
- XMLParser: Responsible for parsing XML files found in a specified directory (and its subdirectories), extracting the relevant data into LabConfigData objects.
- DataAnalysis: A static class that provides methods for analyzing and summarizing data from multiple LabConfigData instances.
- IDataPrinter Interface: Provides an abstraction for outputting parsed XML data.
- DataPrinter: Implements IDataPrinter, handling the presentation of extracted and summarized data in the console.
- Program: The entry point of the application, which sets up the XMLParser, triggers parsing, and prints out the data.

### Features

- Parses labConfig.xml files in a given directory and all its subdirectories.
- Extracts data regarding domain counts, collector counts, and filer counts.
- Summarizes data across all files and displays it in a formatted table in the console.

## Future Improvements

Given additional time, potential improvements might include:

- Making the XML parsing more generic to handle various schemas, enhancing data extraction capabilities.
- Expanding the data analysis capabilities to provide deeper insights and more complex summaries from the parsed information.
- Enriching the test suite to cover more scenarios and ensure robustness across a wider spectrum of XML structures and contents.