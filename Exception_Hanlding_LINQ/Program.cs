using System;

namespace Exception_Handling_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the path of the text file:");
            string filePath = Console.ReadLine();

            TextProcessor textProcessor = new TextProcessor();
            textProcessor.ProcessTex(filePath);

            textProcessor.ProcessingCompleted += (sender, eventArgs) =>
            {
                Console.WriteLine("\nText processing completed!");
            };

            Console.ReadLine();
        }
    }
}

