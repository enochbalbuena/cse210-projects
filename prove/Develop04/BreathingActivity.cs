using System;

namespace MindfulnessApp
{
    public class BreathingActivity : Activity
    {
        private int _inDuration;
        private int _outDuration;

        public BreathingActivity()
        {
            _name = "Breathing Activity";
            _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }

        public override void Run()
        {
            DisplayStartingMessage();

            Console.WriteLine("Enter the duration for breathing in (seconds):");
            _inDuration = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the duration for breathing out (seconds):");
            _outDuration = int.Parse(Console.ReadLine());

            Console.WriteLine("Prepare to begin...");
            ShowSpinner(3);

            int totalCycles = _duration / (_inDuration + _outDuration);
            for (int i = 0; i < totalCycles; i++)
            {
                Console.WriteLine("Breathe in...");
                ShowCountDown(_inDuration);
                Console.WriteLine("Breathe out...");
                ShowCountDown(_outDuration);
            }
            DisplayEndingMessage();
        }

        public new void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }
    }
}

