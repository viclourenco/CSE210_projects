using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // read from escrituras.txt
        string[] scriptureLines = File.ReadAllLines("escrituras.txt");

        List<Scripture> scriptures = new List<Scripture>();

        for (int i = 0; i < scriptureLines.Length; i += 2)
        {
            string reference = scriptureLines[i];
            string text = scriptureLines[i + 1];
            scriptures.Add(new Scripture(reference, text));
        }

        // choose randomly an scripture
        Random random = new Random();
        int randomIndex = random.Next(scriptures.Count);
        Scripture selectedScripture = scriptures[randomIndex];

        while (!selectedScripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetHiddenText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            selectedScripture.HideRandomWord();
        }

        Console.WriteLine("\nEnd.");
    }
}

