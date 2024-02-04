using System;
using System.Threading;

class MindfulnessActivity
{
    public string Name { get; }
    public string Description { get; }

    public MindfulnessActivity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void StartActivity(int duration)
    {
        Console.WriteLine($"\nStarting {Name} activity...");
        Console.WriteLine(Description);
        Console.WriteLine($"Duration: {duration} seconds");
        Thread.Sleep(3000);  // Pause for 3 seconds before starting
    }

    public void EndActivity()
    {
        Console.WriteLine("\nGreat job! You've completed the activity.");
        Console.WriteLine($"You've completed the {Name} activity.");
        Thread.Sleep(3000);  // Pause for 3 seconds before ending
    }
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by guiding you through deep breathing exercises.")
    {
    }

    public void PerformActivity(int duration)
    {
        StartActivity(duration);
        for (int i = 0; i < duration; i++)
        {
            if (i % 2 == 0)
                Console.WriteLine("Breathe in...");
            else
                Console.WriteLine("Breathe out...");
            Thread.Sleep(1000);
        }
        EndActivity();
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
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

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on past experiences to gain insights and understanding.")
    {
    }

    public void PerformActivity(int duration)
    {
        StartActivity(duration);
        string prompt = prompts[new Random().Next(prompts.Length)];
        Console.WriteLine(prompt);
        Thread.Sleep(3000);  // Pause for 3 seconds after showing the prompt

        foreach (string question in questions)
        {
            Console.WriteLine(question);
            Thread.Sleep(3000);  // Pause for 3 seconds after showing each question
            Console.Write("...");  // Simulating spinner animation
            Thread.Sleep(1000);
            Console.Write("\b \b"); // Erase the spinner animation
        }

        EndActivity();
    }
}

class ListingActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on positive aspects of your life by listing things in a certain area.")
    {
    }

    public void PerformActivity(int duration)
    {
        StartActivity(duration);
        string prompt = prompts[new Random().Next(prompts.Length)];
        Console.WriteLine(prompt);
        Console.WriteLine("Get ready to list...");
        Thread.Sleep(3000);  // Pause for 3 seconds before starting to list

        int itemsCount = 0;
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            string item = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(item))
                break;
            itemsCount++;
        }

        Console.WriteLine($"\nYou listed {itemsCount} items.");
        EndActivity();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness Program!\n");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");

        Console.Write("Choose an activity (1-3): ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.Write("Enter duration in seconds: ");
            int duration = int.Parse(Console.ReadLine());
            BreathingActivity activity = new BreathingActivity();
            activity.PerformActivity(duration);
        }
        else if (choice == "2")
        {
            Console.Write("Enter duration in seconds: ");
            int duration = int.Parse(Console.ReadLine());
            ReflectionActivity activity = new ReflectionActivity();
            activity.PerformActivity(duration);
        }
        else if (choice == "3")
        {
            Console.Write("Enter duration in seconds: ");
            int duration = int.Parse(Console.ReadLine());
            ListingActivity activity = new ListingActivity();
            activity.PerformActivity(duration);
        }
        else
        {
            Console.WriteLine("Invalid choice. Please choose a number between 1 and 3.");
        }
    }
}
