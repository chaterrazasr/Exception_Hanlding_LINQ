using System;
using System.Collections.Generic;
using System.Linq;

namespace Exception_Handling_LINQ
{
    public class TextProcessor
    {
        public event EventHandler ProcessingCompleted;

        public void ProcessTex(string filePath)
        {
            try
            {
                string text = ProcessText.ReadTextFile(filePath);
                if (text != null)
                {
                    int wordCount = CountWords(text);
                    Dictionary<char, int> charFrequency = CalculateFrequency(text);
                    string longestWord = FindLongestWord(text);
                    Console.WriteLine($"Total words: {wordCount}");
                    Console.WriteLine("Character frequency:");
                    foreach (var pair in charFrequency)
                    {
                        Console.WriteLine($"{pair.Key}: {pair.Value}");
                    }
                    Console.WriteLine($"Longest word: {longestWord}");
                }
            }
            finally
            {
                OnProcessingCompleted(EventArgs.Empty);
            }
        }

        private int CountWords(string text)
        {
            return text.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        private Dictionary<char, int> CalculateFrequency(string text)
        {
            return text
                .Where(char.IsLetter)
                .GroupBy(char.ToLower)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        private string FindLongestWord(string text)
        {
            return text.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .OrderByDescending(word => word.Length)
                .FirstOrDefault();
        }

        protected virtual void OnProcessingCompleted(EventArgs e)
        {
            ProcessingCompleted?.Invoke(this, e);
        }
    }
}
