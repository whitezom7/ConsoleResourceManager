using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

public class ResourceMonitor
{
    static void UsageMonitor()
    {
        var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        var ramCounter = new PerformanceCounter("Memory", "Available MBytes");

        // Delay for a short time to allow the counters to initialize
        Thread.Sleep(1000);

        while (true)
        {
            // Read CPU and RAM usage
            var cpuUsage = cpuCounter.NextValue();

            // Delay for a short time to obtain accurate CPU usage value
            Thread.Sleep(500);

            var availableRAM = ramCounter.NextValue();

            DriveInfo drive = new DriveInfo("C"); // specify the drive letter
            long totalDiskSpace = drive.TotalSize;
            long usedDiskSpace = drive.TotalSize - drive.TotalFreeSpace;

            Console.WriteLine($"CPU Usage: {cpuUsage:F}%");
            Console.WriteLine($"Available RAM: {availableRAM} MB");
            Console.WriteLine($"Total Disk Space: {totalDiskSpace} bytes");
            Console.WriteLine($"Used Disk Space: {usedDiskSpace} bytes");

            Thread.Sleep(1000);
            Console.Clear(); // Clear the console screen
        }
    }

    static void Main()
    {
        UsageMonitor();
    }
}
