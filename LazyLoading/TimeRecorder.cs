using System;
using System.Diagnostics;

namespace LinqChallenges
{
    internal static class TimeRecorder
    {
        public static void RecordTime(Action action)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine("----------------------------");

            action();

            Console.WriteLine("----------------------------");
            Console.WriteLine($"Total time taken: {stopWatch.Elapsed.TotalSeconds}");
        }
    }
}