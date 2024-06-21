using System;

public class Entry
{
    public string Date { get; set; }
    public string PromptText { get; set; }
    public string EntryText { get; set; }
    public string Mood { get; set; }

    public Entry(string date, string promptText, string entryText, string mood)
    {
        Date = date;
        PromptText = promptText;
        EntryText = entryText;
        Mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {PromptText}");
        Console.WriteLine($"Entry: {EntryText}");
        Console.WriteLine($"Mood: {Mood}");
        Console.WriteLine();
    }
}
