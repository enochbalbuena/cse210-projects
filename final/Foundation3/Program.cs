using System;

namespace EventPlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
            Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");
            Address address3 = new Address("789 Oak St", "London", "ENG", "UK");

            LectureEvent lecture = new LectureEvent("C# Programming Lecture", "An advanced lecture on C# programming.", DateTime.Parse("2023-08-01"), "10:00 AM", address1, "John Doe", 100);
            ReceptionEvent reception = new ReceptionEvent("Networking Reception", "An evening of networking with industry professionals.", DateTime.Parse("2023-08-05"), "6:00 PM", address2, "rsvp@example.com");
            OutdoorGatheringEvent outdoorGathering = new OutdoorGatheringEvent("Summer Picnic", "A fun-filled day in the park.", DateTime.Parse("2023-08-10"), "12:00 PM", address3, "Sunny with a chance of showers");

            DisplayEventDetails(lecture);
            DisplayEventDetails(reception);
            DisplayEventDetails(outdoorGathering);
        }

        static void DisplayEventDetails(Event eventObj)
        {
            Console.WriteLine("Standard Details:");
            Console.WriteLine(eventObj.GetStandardDetails());
            Console.WriteLine();
            
            Console.WriteLine("Full Details:");
            Console.WriteLine(eventObj.GetFullDetails());
            Console.WriteLine();
            
            Console.WriteLine("Short Description:");
            Console.WriteLine(eventObj.GetShortDescription());
            Console.WriteLine();
        }
    }
}
