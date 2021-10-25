using System;
using System.IO;
using System.Linq;
using CsvHelper;
using System.Globalization;
using Microsoft.VisualBasic.FileIO;

namespace Assignment1
{
    public class CSVparser
    {
        static int count = 0;
        public void parse1(String fileName)
        {
            count++;
            try
            {
                int invalid = 0;
                using (var reader = new StreamReader(fileName))
                using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
                {
                    var customers = csvReader.GetRecords<Customer>();
                    var cust = customers.ToList();

                    var DDIR = System.IO.Directory.GetCurrentDirectory()+ "\\Output.csv";
                    using (var stream = File.Open(@DDIR, FileMode.Append))
                    using (var writer = new StreamWriter(stream))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        if (count==1)
                        {
                            csv.WriteHeader<Customer>();
                            csv.NextRecord();
                        }

                        foreach (var customer in cust)
                        {
                            if (String.IsNullOrEmpty(customer.FirstName) || String.IsNullOrEmpty(customer.LastName) || String.IsNullOrEmpty(customer.Street) || String.IsNullOrEmpty(customer.StreetNum) || String.IsNullOrEmpty(customer.Province) || String.IsNullOrEmpty(customer.City) || String.IsNullOrEmpty(customer.Country) || String.IsNullOrEmpty(customer.PostalCode) || String.IsNullOrEmpty(customer.Email) || String.IsNullOrEmpty(customer.PhoneNum)) { invalid++; }
                            else
                            {
                                Console.WriteLine(customer.FirstName);
                                csv.WriteRecord(customer);
                                csv.NextRecord();
                            }

                        }

                    }
                }

                Console.WriteLine("Invalid rows = " + invalid);

            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
            }

        }
        public void parse(String fileName)
        {
            try
            {
                using (TextFieldParser parser = new TextFieldParser(fileName))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    int rowCount = 0;
                    while (!parser.EndOfData)
                    {
                        //Process row
                        string[] fields = parser.ReadFields();
                        int count = 0;
                        foreach (string field in fields)
                        {
                            if (field.Equals(""))
                                count++;
                        }
                        if (count > 0)
                        {
                            Console.WriteLine("Row skipped");
                        }
                        else
                        {
                            rowCount++;
                        }
                    }

                    Console.WriteLine("Valid rows = " + rowCount);
                }

            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
            }

        }
    }
}
