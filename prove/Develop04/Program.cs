using System;
using System.Collections.Generic;
using System.IO;


class Program
{
    static void Main()
    {
      Console.WriteLine("Welcome to the Journal Program!");
        while (true)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    ViewDiary();
                    break;
                case "3":
                    SaveResponsesToFile();
                    break;
                case "4":
                    LoadDiaryFromFile();
                    break;
                case "5":
                    Console.WriteLine("See you tomorrow!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
     static List<string> prompts = new List<string>
    {
        "Who was the most interesting person you interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I could do one thing today, what would it be?",
        "How did I spend time with my family today?",
        "Write something you could learn from the scriptures today"
    };

    static List<string> diaryEntries = new List<string>();
    static string responsesFileName = "journal.txt";
    
    static void WriteNewEntry()
    {
        Random random = new Random();
        int randomIndex = random.Next(prompts.Count);
        string prompt = prompts[randomIndex];

        Console.WriteLine(prompt);
        string response = Console.ReadLine();
        DateTime date = DateTime.Now;

        string entry = $"{date}: {prompt}\n{response}\n";
        diaryEntries.Add(entry);

    }

    static void ViewDiary()
    {
        if (diaryEntries.Count == 0)
        {
            Console.WriteLine("The diary is empty.");
        }
        else
        {
            Console.WriteLine("Diary Entries:");
            foreach (var entry in diaryEntries)
            {
                Console.WriteLine(entry);
            }
        }
    }

    static void SaveDiaryToFile()
    {
        Console.Write("Enter the filename to save the diary: ");
        string filename = Console.ReadLine();

        try
        {
            File.WriteAllLines(filename, diaryEntries);
            Console.WriteLine("Diary saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error while saving the diary: " + ex.Message);
        }
    }

    static void LoadDiaryFromFile()
    {
        Console.Write("Enter the filename to load the diary: ");
        string filename = Console.ReadLine();

        try
        {
            diaryEntries = new List<string>(File.ReadAllLines(filename));
            Console.WriteLine("Diary loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error while loading the diary: " + ex.Message);
        }
    }
  static void SaveResponsesToFile()
  {
      if (diaryEntries.Count == 0)
      {
          Console.WriteLine("The diary is empty. There are no responses to save.");
          return;
      }

      try
      {
          using (StreamWriter writer = new StreamWriter(responsesFileName))
          {
              foreach (var entry in diaryEntries)
              {
                  writer.WriteLine(entry); 
              }
          }
          Console.WriteLine("Responses saved successfully!");
      }
      catch (Exception ex)
      {
          Console.WriteLine("Error while saving responses: " + ex.Message);
      }
  }

}
