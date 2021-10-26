using System;
using System.IO;
using System.Linq;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;

namespace Assignment1
{
    public class CSVparser
    {
        public static int count = 0;
        public static int invalid = 0;
        public static int valid = 0;
        public void parse(String fileName)
        {
            count++;
            String[] split = fileName.Split("\\");
            var date = split[split.Length - 4] + "/" + split[split.Length - 3] + "/" + split[split.Length - 2];
            
            //int fileValidRowCount = 0;
            //int fileInvalidRowCount = 0;

            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    MissingFieldFound = null,
                    HeaderValidated = null,
                    BadDataFound = null,
                    ShouldSkipRecord = record => record.Record.All(string.IsNullOrWhiteSpace)
                };
                using (var reader = new StreamReader(fileName))
                using (var csvReader = new CsvReader(reader, config))
                {
                    var customers = csvReader.GetRecords<Customer>();
                    var cust = customers.ToList();

                    var pathString = System.IO.Directory.GetCurrentDirectory() + "\\Output";
                    System.IO.Directory.CreateDirectory(pathString);
                    var dir = pathString + "\\Output.csv";
                    using (var stream = File.Open(@dir, FileMode.Append))
                    using (var writer = new StreamWriter(stream))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        if (count==1)
                        {
                            csv.WriteHeader<Customer>();
                            csv.WriteField("Date");
                            csv.NextRecord();
                        }
                        int i = 0;
                        foreach (var customer in cust)
                        {
                            i++;
                            if (String.IsNullOrEmpty(customer.FirstName) || String.IsNullOrEmpty(customer.LastName) || String.IsNullOrEmpty(customer.Street) || String.IsNullOrEmpty(customer.StreetNum) || String.IsNullOrEmpty(customer.Province) || String.IsNullOrEmpty(customer.City) || String.IsNullOrEmpty(customer.Country) || String.IsNullOrEmpty(customer.PostalCode) || String.IsNullOrEmpty(customer.Email) || String.IsNullOrEmpty(customer.PhoneNum)) { invalid++; Console.WriteLine("Invalid data - Skipped row "+i); }
                            else
                            {
                                valid++;

                                csv.WriteRecord(customer);
                                csv.WriteField(date);
                                csv.NextRecord();
                            }

                        }

                    }
                }

                //Console.WriteLine("Valid rows = " + fileValidRowCount);
                //Console.WriteLine("Skipped rows = " + fileInvalidRowCount);

            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("'path' exceeds the maxium supported path length.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to create this file.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"An IO exception occurred:\nError code: " +
                                  $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
            }
            catch (CsvHelper.ReaderException e)
            {
                Console.WriteLine($"A Csv reader exception occurred:\nError code: " +
                                  $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
            }


        }
   
    }
}
