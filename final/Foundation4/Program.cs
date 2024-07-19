using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            Running running = new Running(DateTime.Parse("2023-11-03"), 30, 5); // 5 km
            Cycling cycling = new Cycling(DateTime.Parse("2023-11-04"), 45, 20); // 20 kph
            Swimming swimming = new Swimming(DateTime.Parse("2023-11-05"), 60, 40); // 40 laps

            List<Activity> activities = new List<Activity> { running, cycling, swimming };

            foreach (var activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
                Console.WriteLine();
            }
        }
    }
}
