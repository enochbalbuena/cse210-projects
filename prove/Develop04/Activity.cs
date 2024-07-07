using System;
using System.Threading;

namespace MindfulnessApp
{
    public abstract class Activity
    {
        protected string _name;
        protected string _description;
        protected int _duration;

        public Activity()
        {
        }

        public void DisplayStartingMessage()
        {
            Console.WriteLine($"Starting {_name}...");
            Console.WriteLine(_description);
            Console.WriteLine("Enter duration in seconds:");
            _duration = int.Parse(Console.ReadLine());
        }

        public void DisplayEndingMessage()
        {
            Console.WriteLine("Good job!");
            Console.WriteLine($"You have completed {_name} for {_duration} seconds.");
            ShowSpinner(3);
            Console.WriteLine();
        }

        public void ShowSpinner(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write("|");
                Thread.Sleep(500);
                Console.Write("\b \b");
                Console.Write("/");
                Thread.Sleep(500);
                Console.Write("\b \b");
            }
        }

        public virtual void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        public abstract void Run();
    }
}
