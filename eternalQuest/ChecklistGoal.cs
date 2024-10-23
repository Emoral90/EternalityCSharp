public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            Console.WriteLine($"Goal progress! You've earned {_points} points.");

            if (_amountCompleted == _target)
            {
                Console.WriteLine($"Goal Completed! You've earned an additional {_bonus} points.");
            }
        }
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString() => $"[ {(IsComplete() ? "X" : " ")} ] {_shortName}: {_description} (Completed {_amountCompleted}/{_target})";

    public override string GetStringRepresentation() => $"ChecklistGoal:{_shortName},{_description},{_points},{_amountCompleted},{_target},{_bonus}";
}