using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example usage
            var scripture = new Scripture("John 3:16", "For God so loved the world that he gave his only Son, so that everyone who believes in him may not perish but may have eternal life.");

            var memorizer = new Memorizer(scripture);
            memorizer.Run();
        }
    }

    class Memorizer
    {
        private readonly Scripture _scripture;
        private List<int> _hiddenIndices;

        public Memorizer(Scripture scripture)
        {
            _scripture = scripture;
            _hiddenIndices = new List<int>();
        }

        public void Run()
        {
            DisplayScripture();

            while (_hiddenIndices.Count < _scripture.Words.Count)
            {
                Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
                var input = Console.ReadLine();

                if (input == "quit")
                    break;

                HideRandomWords();
                DisplayScripture();
            }
        }

        private void DisplayScripture()
        {
            Console.Clear();
            Console.WriteLine($"Scripture: {_scripture.Reference}");
            Console.WriteLine();

            for (int i = 0; i < _scripture.Words.Count; i++)
            {
                if (_hiddenIndices.Contains(i))
                    Console.Write("____ ");
                else
                    Console.Write(_scripture.Words[i] + " ");
            }

            Console.WriteLine("\n");
        }

        private void HideRandomWords()
        {
            Random random = new Random();
            int wordsToHide = random.Next(1, 3); // Hide 1-2 words at a time

            for (int i = 0; i < wordsToHide; i++)
            {
                int index = random.Next(_scripture.Words.Count);
                if (!_hiddenIndices.Contains(index))
                    _hiddenIndices.Add(index);
            }
        }
    }

    class Scripture
    {
        public string Reference { get; }
        public List<string> Words { get; }

        public Scripture(string reference, string text)
        {
            Reference = reference;
            Words = text.Split(' ').ToList();
        }
    }
}
