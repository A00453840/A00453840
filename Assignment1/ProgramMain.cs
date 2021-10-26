using System;
using System.IO;

namespace Assignment1
{
    public class ProgramMain
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Execution stared.. Logs will be written to logs/logs.txt file");
                DirWalker dirWalker = new DirWalker();

                var pathString = System.IO.Directory.GetCurrentDirectory() + "\\logs";
                System.IO.Directory.CreateDirectory(pathString);
                var dir = pathString + "\\logs.txt";
                var stream = File.Open(@dir, FileMode.Append);
                var streamwriter = new StreamWriter(stream);
                streamwriter.AutoFlush = true;
                Console.SetOut(streamwriter);
                Console.SetError(streamwriter);

                var watch = new System.Diagnostics.Stopwatch();

                watch.Start();

                //Update the location of sample date directory here
                dirWalker.walk(@"C:\Users\nikhi\source\repos\MCDA5510_Assignments\Sample Data");

                watch.Stop();

                Console.WriteLine($"Total time elapsed : {watch.Elapsed}");
                Console.WriteLine("Total number of valid rows : " + CSVparser.valid);
                Console.WriteLine("Total number of invalid rows : " + CSVparser.invalid);
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
        }
    }
}
