using System;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        while(true)
        {
            Console.WriteLine("Select an activity:");
            Console.WriteLine("1: Complete a Simple Goal");
            Console.WriteLine("1: Record an Eternal Goal");
            Console.WriteLine("1: Complete a Checklist Goal");
            string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                CreateGoal();
                break;
            case "2":
                RecordEvent();
                break;
            case "3":
                ListGoals();
                break;
            case "4":
                DisplayPlayerInfo();
                break;
            case "5":
                SaveGoals();
                break;
            case "6":
                LoadGoals();
                break;
            case "7":
                Console.WriteLine("Exiting...");
                return;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;        
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    public void ListGoals()
    {
        Console.WriteLine("Goals:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal(Goal goal)
    {
        Console.WriteLine("Select a goal type:");
        Console.WriteLine("1: Simple Goal");
        Console.WriteLine("2: Eternal Goal");
        Console.WriteLine("3: Checklist Goal");

        string choice = Console.ReadLine();
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points for this goal: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter target completion count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points for completing target: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    public void RecordEvent(string goalName)
    {
        Console.WriteLine("Select a goal to record an event:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {_goals[i].GetDetailsString()}");
        }

        int goalIndex = int.Parse(Console.ReadLine()) - 1;
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            _goals[goalIndex].RecordEvent();
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            string[] lines = File.ReadAllLines("goals.txt");
            foreach (string line in lines)
            {
                // Parse the line and recreate the goal object
                string[] parts = line.Split(':');
                if (parts[0] == "SimpleGoal")
                {
                    string[] data = parts[1].Split(',');
                    _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2])));
                }
            }
        }
    }
}