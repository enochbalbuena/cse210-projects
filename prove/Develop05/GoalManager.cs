using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private List<string> _rewards;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _rewards = new List<string>();
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine($"\nYou have {_score} points and are at level {_level}");
            Console.WriteLine("Unlocked Rewards: " + string.Join(", ", _rewards));
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoalMenu();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoalsMenu();
                    break;
                case "4":
                    LoadGoalsMenu();
                    break;
                case "5":
                    RecordEventMenu();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nPlayer Score: {_score}");
        Console.WriteLine($"Player Level: {_level}");
        Console.WriteLine("Unlocked Rewards: " + string.Join(", ", _rewards));
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nGoals:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        var goal = _goals[goalIndex];
        goal.RecordEvent();
        _score += goal.Points;
        if (goal.IsComplete() && goal is ChecklistGoal checklistGoal)
        {
            _score += checklistGoal.Bonus;
        }
        UpdateLevel();
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            outputFile.WriteLine(_level);
            outputFile.WriteLine(string.Join(",", _rewards));
            foreach (var goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);
        _rewards = lines[2].Split(',').ToList();
        _goals.Clear();

        foreach (string line in lines.Skip(3))
        {
            string[] parts = line.Split(':');
            string type = parts[0];
            string[] details = parts[1].Split(',');

            Goal goal = type switch
            {
                "SimpleGoal" => new SimpleGoal(details[0], details[1], int.Parse(details[2])),
                "EternalGoal" => new EternalGoal(details[0], details[1], int.Parse(details[2])),
                "ChecklistGoal" => new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[4]), int.Parse(details[5]), int.Parse(details[3])),
                _ => throw new Exception("Unknown goal type")
            };
            _goals.Add(goal);
        }
    }

    private void CreateGoalMenu()
    {
        Console.WriteLine("\nCreate a New Goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose the type of goal: ");
        string choice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter goal points: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                CreateGoal(new SimpleGoal(name, description, points));
                break;
            case "2":
                CreateGoal(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter target number of completions: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                CreateGoal(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid choice. Goal not created.");
                break;
        }
    }

    private void RecordEventMenu()
    {
        Console.WriteLine("\nRecord an Event:");
        ListGoalNames();
        Console.Write("Enter the number of the goal to record: ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            RecordEvent(goalIndex);
            Console.WriteLine("Event recorded.");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    private void SaveGoalsMenu()
    {
        Console.Write("\nEnter filename to save goals: ");
        string filename = Console.ReadLine();
        SaveGoals(filename);
        Console.WriteLine("Goals saved.");
    }

    private void LoadGoalsMenu()
    {
        Console.Write("\nEnter filename to load goals: ");
        string filename = Console.ReadLine();
        LoadGoals(filename);
        Console.WriteLine("Goals loaded.");
    }

    private void UpdateLevel()
    {
        int newLevel = CalculateLevel(_score);
        if (newLevel > _level)
        {
            _level = newLevel;
            UnlockReward();
        }
    }

    private int CalculateLevel(int score)
    {
        return score / 100 + 1;
    }

    private void UnlockReward()
    {
        string reward = $"Level {_level} Reward";
        _rewards.Add(reward);
        Console.WriteLine($"Congratulations! You've reached level {_level} and unlocked: {reward}");
    }
}
