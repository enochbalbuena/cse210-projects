using System;

namespace MindfulnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Select an activity:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Listing Activity");
                Console.WriteLine("3. Reflecting Activity");
                Console.WriteLine("4. Exit");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 4)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                Activity activity = null;
                switch (choice)
                {
                    case 1:
                        activity = new BreathingActivity();
                        break;
                    case 2:
                        activity = new ListingActivity();
                        break;
                    case 3:
                        activity = new ReflectingActivity();
                        break;
                }

                activity?.Run();
            }
        }
    }
}
