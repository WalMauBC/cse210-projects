using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public JournalEntry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }
}

class Journal
{
    private List<JournalEntry> entries;

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void AddEntry(string prompt, string response, string date)
    {
        JournalEntry entry = new JournalEntry(prompt, response, date);
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"{entry.Date}: {entry.Prompt}\n\t{entry.Response}\n");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                outputFile.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split(",");
            string date = parts[0];
            string prompt = parts[1];
            string response = parts[2];

            AddEntry(prompt, response, date);
        }
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string randomPrompt = GetRandomPrompt();
                    Console.WriteLine($"Prompt: {randomPrompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    string currentDate = DateTime.Now.ToShortDateString();
                    journal.AddEntry(randomPrompt, response, currentDate);
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter the filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;

                case "4":
                    Console.Write("Enter the filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;

                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static string GetRandomPrompt()
    {
        // Add your list of prompts here
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
            // Add more prompts as needed
        };

        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}
