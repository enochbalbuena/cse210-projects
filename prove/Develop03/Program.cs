/*
 * This program hides words one by one in scriptures, including multiple verses. It picks a random scripture from a library and ends when all words are hidden or the user types 'quit'.
 */


using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
            new Scripture(new Reference("Philippians", 4, 13), "I can do all this through him who gives me strength."),
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            new Scripture(new Reference("Psalm", 23, 1, 2), "The Lord is my shepherd; I shall not want. He makes me lie down in green pastures; He leads me beside still waters."),
            new Scripture(new Reference("Isaiah", 40, 31), "But they that wait upon the Lord shall renew their strength; they shall mount up with wings as eagles; they shall run, and not be weary; and they shall walk, and not faint."),
            new Scripture(new Reference("Matthew", 5, 14, 16), "You are the light of the world. A city that is set on a hill cannot be hidden. Neither do men light a candle, and put it under a bushel, but on a candlestick; and it gives light unto all that are in the house. Let your light so shine before men, that they may see your good works, and glorify your Father which is in heaven."),
            new Scripture(new Reference("Romans", 8, 28), "And we know that in all things God works for the good of those who love him, who have been called according to his purpose."),
            new Scripture(new Reference("Jeremiah", 29, 11), "For I know the plans I have for you, declares the Lord, plans to prosper you and not to harm you, plans to give you hope and a future."),
            new Scripture(new Reference("Joshua", 1, 9), "Have I not commanded you? Be strong and courageous. Do not be afraid; do not be discouraged, for the Lord your God will be with you wherever you go."),
            new Scripture(new Reference("Hebrews", 11, 1), "Now faith is confidence in what we hope for and assurance about what we do not see."),
            new Scripture(new Reference("1 Corinthians", 13, 4, 7), "Love is patient, love is kind. It does not envy, it does not boast, it is not proud. It does not dishonor others, it is not self-seeking, it is not easily angered, it keeps no record of wrongs. Love does not delight in evil but rejoices with the truth. It always protects, always trusts, always hopes, always perseveres."),
            new Scripture(new Reference("Galatians", 5, 22, 23), "But the fruit of the Spirit is love, joy, peace, forbearance, kindness, goodness, faithfulness, gentleness and self-control. Against such things there is no law."),
            new Scripture(new Reference("Ephesians", 2, 8, 9), "For it is by grace you have been saved, through faith—and this is not from yourselves, it is the gift of God—not by works, so that no one can boast."),
            new Scripture(new Reference("2 Timothy", 1, 7), "For the Spirit God gave us does not make us timid, but gives us power, love and self-discipline."),
            new Scripture(new Reference("1 Peter", 5, 7), "Cast all your anxiety on him because he cares for you."),
            new Scripture(new Reference("James", 1, 2, 3), "Consider it pure joy, my brothers and sisters, whenever you face trials of many kinds, because you know that the testing of your faith produces perseverance.")
        };

        Random random = new Random();

        Scripture selectedScripture = scriptures[random.Next(scriptures.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide random words, or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            selectedScripture.HideRandomWords(3);

            if (selectedScripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(selectedScripture.GetDisplayText());
                Console.WriteLine();
                Console.WriteLine("All words are hidden. Press Enter to exit.");
                Console.ReadLine();
                break;
            }
        }
    }
}