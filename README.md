# VersionControlApp
 
## Objective

The objective of this program is to increment a version number based on its inputted version type. If the version type is ‘minor’, the minor section of the version number is increased by 1 and the patch section is put to 0. If the version type is ‘patch’, the patch section is increased by 1. 

The initial version number is from a JSON file inside the project. This also contains other project details. Once the version number has been incremented, it is saved back to the original JSON file with the other information untouched. 

It is a console application built in C# and .Net 8. 

## Overview

The program expects a string input to start. The expected arguments are ‘patch’ and ‘minor’. The program will not fail if anything else is added but will not alter the version number. The input is case insensitive. 

The program starts by calling the GetProjectDetails method which accepts a string parameter for the filepath. This reads the file. The file path is hard coded in the application in Program.cs with the value passed to the UpdateVersionNumber method. The file is expected to be in ProjectDetails structure (found in the Model folder). If the file cannot be found or is not in the suitable format required, it throws an exception and fails. 

The version number is then extracted from the JSON of the file.

The IncrementVersionNo method is then called. The version type and number are passed in as string parameters and it returns the updated version number. This function splits the inputted version number string into each of its different three parts. Based on the version type, the version number is incremented. Then the result of this method is assigned to the ‘Version’ field in the file JSON object.

The final method to be called is SaveUpdatedProjectDetails. This takes the string parameter of the file path and the file JSON object and converts it back to JSON before saving it to the file again. 

## Unit Tests

Tests have been created for the UpdateVersionNumber function and the IncrementVersionNo. As GetProjectDetails and SaveUpdatedProjectDetails method uses an external library and inbuilt functions, there is no need to test these as they have already been tested by their creators.

As the logic of updating the version number is completed in IncrementVersionNo and the method returns the updated version number, it is important to test this to make sure the program is working correctly. A range of tests has been created including when the methods would fail e.g when the JSON file is not correct or not there. There are also tests for a range of different inputs, ensuring the methods will only update the version number when it should. 