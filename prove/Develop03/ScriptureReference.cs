using System;

public class ScriptureReference
{
    public string Book { get; set; }
    public int Chapter { get; set; }
    public int StartVerse { get; set; }
    public int EndVerse { get; set; }

    public ScriptureReference(string reference)
    {
        string[] parts = reference.Split(' ');

        // Extract book name
        Book = parts[0];

        // Extract chapter and verse part
        string chapterVersePart = parts[1];
        string[] chapterVerse = chapterVersePart.Split(':');

        Chapter = int.Parse(chapterVerse[0]);

        if (chapterVerse[1].Contains("-"))
        {
            string[] verses = chapterVerse[1].Split('-');
            StartVerse = int.Parse(verses[0]);
            EndVerse = int.Parse(verses[1]);
        }
        else
        {
            StartVerse = EndVerse = int.Parse(chapterVerse[1]);
        }
    }
}
