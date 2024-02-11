using System;
using System.Collections.Generic;
using System.IO;


public abstract class Activity
{
    public string Name { get; set; }
    public int Value { get; set; }

    public Activity(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public abstract void RecordActivity();

    public abstract string GetStringRepresentation();
}


public class SimpleGoal : Activity
{
    public SimpleGoal(string name, int value) : base(name, value) { }

    public override void RecordActivity()
    {
        Console.WriteLine($"Congratulations! You've completed the goal: {Name}");
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{Name},{Value}";
    }
}


public class EternalGoal : Activity
{
    public EternalGoal(string name, int value) : base(name, value) { }

    public override void RecordActivity()
    {
        Console.WriteLine($"Keep up the good work on your eternal goal: {Name}");
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{Name},{Value}";
    }
}


public class ChecklistGoal : Activity
{
    private int completionCount;
    private int requiredCount;

    public int CompletionCount
    {
        get { return completionCount; }
        set { completionCount = value; }
    }

    public int RequiredCount
    {
        get { return requiredCount; }
    }

    public ChecklistGoal(string name, int value, int requiredCount) : base(name, value)
    {
        this.requiredCount = requiredCount;
    }

    public override void RecordActivity()
    {
        completionCount++;
        Console.WriteLine($"You've completed the checklist goal: {Name}");
        if (completionCount == requiredCount)
        {
            Console.WriteLine($"Congratulations! You've completed the checklist goal: {Name}");
            Value += 500;
        }
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{Name},{Value},{completionCount},{requiredCount}";
    }
}


public class EternalQuestManager
{
    private List<Activity> goals = new List<Activity>();
    private int score = 0;

    public void AddGoal(Activity goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        Activity goal = goals.Find(g => g.Name == goalName);
        if (goal != null)
        {
            goal.RecordActivity();
            score += goal.Value;
        }
        else
        {
            Console.WriteLine("Goal not found!");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Your current score is: {score}");
    }

    public void DisplayGoals()
    {
        foreach (Activity goal in goals)
        {
            if (goal is ChecklistGoal)
            {
                ChecklistGoal checklistGoal = (ChecklistGoal)goal;
                Console.WriteLine($"{goal.Name} - Completed {checklistGoal.CompletionCount}/{checklistGoal.RequiredCount} times");
            }
            else
            {
                Console.WriteLine($"{goal.Name} - [ ]");
            }
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Activity goal in goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split(":");
                string type = parts[0];
                string[] details = parts[1].Split(",");
                string name = details[0];
                int value = int.Parse(details[1]);
                if (type == "SimpleGoal")
                {
                    AddGoal(new SimpleGoal(name, value));
                }
                else if (type == "EternalGoal")
                {
                    AddGoal(new EternalGoal(name, value));
                }
                else if (type == "ChecklistGoal")
                {
                    int completionCount = int.Parse(details[2]);
                    int requiredCount = int.Parse(details[3]);
                    AddGoal(new ChecklistGoal(name, value, requiredCount) { CompletionCount = completionCount });
                }
            }
        }
        else
        {
            Console.WriteLine("No goals file found. Starting with empty goals list.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
       
        EternalQuestManager questManager = new EternalQuestManager();

       
        questManager.LoadGoals("goals.txt");

  
        questManager.AddGoal(new SimpleGoal("Run a Marathon", 1000));
        questManager.AddGoal(new EternalGoal("Read Scriptures", 100));
        questManager.AddGoal(new ChecklistGoal("Attend Temple", 50, 10));


        questManager.RecordEvent("Read Scriptures");
        questManager.RecordEvent("Attend Temple");
        questManager.RecordEvent("Attend Temple");
        questManager.RecordEvent("Attend Temple");
        questManager.RecordEvent("Attend Temple");
        questManager.RecordEvent("Attend Temple");
        questManager.RecordEvent("Attend Temple");
        questManager.RecordEvent("Attend Temple");
        questManager.RecordEvent("Attend Temple");
        questManager.RecordEvent("Attend Temple"); 
        questManager.RecordEvent("Run a Marathon");


        questManager.DisplayGoals();
        questManager.DisplayScore();

       
        questManager.SaveGoals("goals.txt");
    }
}
