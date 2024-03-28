# XML Parser for LabConfig.xml files

## Overview

This project contains a simple C# console application that parses `labConfig.xml` files to extract data related to domains, collectors, and filers. 
Each file's data is represented by a `LabConfigData` object, and the application prints a summary table to the console, 
displaying the information for each file and a total summary for all files processed.

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

- LabConfigData: A class that represents the data structure for the lab configuration data.
- XMLParser: A class that handles the parsing of XML files and stores the extracted data.
- Program: The entry point of the application, which sets up the XMLParser, triggers parsing, and prints out the data.

### Features

- Parses labConfig.xml files in a given directory and all its subdirectories.
- Extracts data regarding domain counts, collector counts, and filer counts.
- Summarizes data across all files and displays it in a formatted table in the console.