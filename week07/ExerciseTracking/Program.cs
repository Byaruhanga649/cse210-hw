using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a list of activities
        List<Activity> activities = new List<Activity>();

        // Add one instance of each type
        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 3.0));   // Running: 3 miles in 30 min
        activities.Add(new Cycling(new DateTime(2022, 11, 3), 45, 15.0));  // Cycling: 15 mph for 45 min
        activities.Add(new Swimming(new DateTime(2022, 11, 3), 60, 40));   // Swimming: 40 laps in 60 min

        // Display summary for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
