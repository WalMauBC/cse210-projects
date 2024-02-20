using System;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> goals;

    public GoalManager()
    {
        goals = new List<Goal>();
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public Goal FindGoalByName(string name)
    {
        return goals.Find(g => g.Name == name);
    }

    public void RecordCompletion(string name)
    {
        Goal goal = FindGoalByName(name);
        if (goal != null)
        {
            goal.RecordCompletion();
        }
        else
        {
            Console.WriteLine("Goal not found");
        }
    }

    public void DisplayScore()
    {
        int totalScore = 0;
        foreach (Goal goal in goals)
        {
            totalScore += goal.Value;
        }
        Console.WriteLine($"Total Score: {totalScore}");
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Goal goal in goals)
            {
                outputFile.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Value}");
            }
        }
    }
}

public abstract class Goal
{
    public string Name { get; set; }
    public int Value { get; protected set; }

    public abstract void RecordCompletion();
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public override void RecordCompletion()
    {
        Value = 1;
    }
}

public class AchievementGoal : Goal
{
    public AchievementGoal(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public override void RecordCompletion()
    {
        Value++;
    }
}

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        // Add some goals
        manager.AddGoal(new SimpleGoal("Goal 1", 10));
        manager.AddGoal(new AchievementGoal("Goal 2", 20));

        // Record completions
        manager.RecordCompletion("Goal 1");
        manager.RecordCompletion("Goal 2");
        manager.RecordCompletion("Goal 2");

        // Display score
        manager.DisplayScore();

        // Save to file
        manager.SaveToFile("goals.txt");
    }
}