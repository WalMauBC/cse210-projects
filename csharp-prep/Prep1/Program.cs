using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your first name? ");

        String first_name = Console.ReadLine();

        Console.WriteLine("What is your last name? ");

        String last_name = Console.ReadLine();

        Console.WriteLine($"Your name is {last_name}, {first_name} {last_name}.");

    }
}