using System;

namespace Assignment1
{
    public class ProgramMain
    {
        public static void Main(string[] args)
        {
            DirWalker dirWalker = new DirWalker();
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            dirWalker.walk(@"C:\Users\nikhi\source\repos\MCDA5510_Assignments\SampleData_C");
            watch.Stop();
            Console.WriteLine($"Total time elapsed : {watch.ElapsedMilliseconds} ms");
        }
    }
}
