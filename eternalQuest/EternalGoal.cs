public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Goal recorded! You've earned {_points} points.");
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString() => $"[ ] {_shortName}: {_description}";

    public override string GetStringRepresentation() => $"EternalGoal:{_shortName},{_description},{_points}";
}