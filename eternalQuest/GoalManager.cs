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
        // Initial menu and user interaction
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    public void ListGoals()
    {
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        var goal = _goals.Find(g => g.GetStringRepresentation().Contains(goalName));
        if (goal != null)
        {
            // goal.RecordEvent();
            // _score += goal.IsComplete() ? _points : 0; // Update based on type
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