using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LazyLoading;

internal static class TimeRecorder
{
    public static void RecordTime(Action action)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        Console.WriteLine("----------------------------------");

        action();

        Console.WriteLine("----------------------------------");
        Console.WriteLine($"Total time taken: {stopWatch.Elapsed.TotalSeconds}");
    }

    public static async Task RecordTime(Task task)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        Console.WriteLine("----------------------------------");

        await task;

        Console.WriteLine("----------------------------------");
        Console.WriteLine($"Total time taken: {stopWatch.Elapsed.TotalSeconds}");
    }
}