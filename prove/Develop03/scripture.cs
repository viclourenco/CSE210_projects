using System;
using System.Collections.Generic;
using System.Linq;


// Classe para representar uma escritura
class Scripture
{
    public ScriptureReference Reference { get; set; }
    public List<Word> Words { get; set; }

    public Scripture(string reference, string text)
    {
        Reference = new ScriptureReference(reference);
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public bool AllWordsHidden()
    {
        return Words.All(word => word.IsHidden);
    }

    public void HideRandomWord()
    {
        var random = new Random();
        int randomIndex = random.Next(0, Words.Count);

        // Check if the word is already hidden, and if it is, try again
        while (Words[randomIndex].IsHidden)
        {
            randomIndex = random.Next(0, Words.Count);
        }

        Words[randomIndex].IsHidden = true;
    }

    public string GetHiddenText()
    {
        return string.Join(" ", Words.Select(word => word.IsHidden ? "____" : word.Text));
    }
}
