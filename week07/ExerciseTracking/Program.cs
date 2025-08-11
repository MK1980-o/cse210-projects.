/*
 * This program enhances the basic exercise tracker by adding intuitive emojis to quickly identify activity types 
 * and a weekly summary showing total distance, total time, and average speed for all activities combined. 
 * These features improve readability and provide useful insights at a glance.
 */

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running("03 Nov 2022", 30, 3.0));
        activities.Add(new Cycling("03 Nov 2022", 30, 6.0));
        activities.Add(new Swimming("03 Nov 2022", 30, 40));

        double totalDistance = 0;
        double totalLength = 0;

        Console.WriteLine("Activity Summaries:");
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            totalDistance += activity.GetDistance();
            totalLength += activity.Length;
        }

        double avgSpeed = (totalLength > 0) ? (totalDistance / totalLength) * 60 : 0;

        Console.WriteLine("\n--- Weekly Totals ---");
        Console.WriteLine($"Total Distance: {totalDistance:F1} miles");
        Console.WriteLine($"Total Time: {totalLength} minutes");
        Console.WriteLine($"Average Speed: {avgSpeed:F1} mph");
    }
}
