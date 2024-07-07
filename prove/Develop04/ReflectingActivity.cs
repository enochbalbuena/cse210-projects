using System;
using System.Collections.Generic;
using System.Linq;

namespace MindfulnessApp
{
    public class ReflectingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        private List<string> _unusedPrompts;
        private List<string> _unusedQuestions;

        public ReflectingActivity()
        {
            _name = "Reflecting Activity";
            _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
            _unusedPrompts = new List<string>(_prompts);
            _unusedQuestions = new List<string>(_questions);
        }

        public override void Run()
        {
            DisplayStartingMessage();

            string prompt = GetRandomPrompt();
            Console.WriteLine(prompt);
            Console.WriteLine("When you have something in mind, press Enter to continue...");
            Console.ReadLine();

            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            while (DateTime.Now < endTime)
            {
                string question = GetRandomQuestion();
                Console.WriteLine(question);
                ShowSpinner(10);
            }

            DisplayEndingMessage();
        }

        private string GetRandomPrompt()
        {
            if (_unusedPrompts.Count == 0)
            {
                _unusedPrompts = new List<string>(_prompts);
            }

            var random = new Random();
            int index = random.Next(_unusedPrompts.Count);
            string selectedPrompt = _unusedPrompts[index];
            _unusedPrompts.RemoveAt(index);

            return selectedPrompt;
        }

        private string GetRandomQuestion()
        {
            if (_unusedQuestions.Count == 0)
            {
                _unusedQuestions = new List<string>(_questions);
            }

            var random = new Random();
            int index = random.Next(_unusedQuestions.Count);
            string selectedQuestion = _unusedQuestions[index];
            _unusedQuestions.RemoveAt(index);

            return selectedQuestion;
        }
    }
}
