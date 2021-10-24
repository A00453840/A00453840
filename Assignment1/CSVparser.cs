using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Assignment1
{
    public class CSVparser
    {
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
