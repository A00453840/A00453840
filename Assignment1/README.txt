C# File Parser

This repo contains solution for MCDA5510 - Asssignment 1

The goal here is to write a program which traverse recursively through a directory structure containing customers information in the form of multiple csv files and aggregate it into a single csv file (excluding the incomlete records).

Customer.cs - This file has a class that contains all the attributes of a customer such as First Name, Last Name etc.,
DirWalker.cs - This file is used to recursively traverse through a given directory structure
CSVparser.cs - This file is used to traverse through a .csv file, read the records, check if they are valid and aggregate them into a single file - Output.csv
ProgramMain.cs - This file contains the Main method. ("Update the target directory structure with sample data in this file")

Assumptions

   1. Any record with an empty field is considered as a invalid record and is not written to Output.csv file.


Approach:

    Loop through each .csv file in the given directory structure.
    Parse the .csv file one row at a time.
    Read each field within a row to determine if the row is valid.
        Row is valid if it has all fields.
        Row is skipped if it has any empty field and is logged.
    Each row is stored as an objec tof class Customer and then written into Output.csv file (Any repeated headers are ignored).
    Total number of Valid rows, Invalid Rows and Total execution time is written into the log file. 