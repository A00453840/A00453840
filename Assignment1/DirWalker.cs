using System;
using System.IO;

namespace Assignment1
{
    public class DirWalker
    {
        public void walk(String path)
        {

            string[] list = Directory.GetDirectories(path);
            var watch = new System.Diagnostics.Stopwatch();
            CSVparser csvParser = new CSVparser();

            if (list == null) return;

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath);
                    Console.WriteLine("Dir:" + dirpath);
                }
            }
            string[] fileList = Directory.GetFiles(path);
            foreach (string filepath in fileList)
            {
                watch.Start();
                Console.WriteLine("Iterating file - " + filepath);
                csvParser.parse(filepath);
                watch.Stop();
                Console.WriteLine($"Time taken to read this file : {watch.ElapsedMilliseconds} ms");
            }
        }
    }
}
