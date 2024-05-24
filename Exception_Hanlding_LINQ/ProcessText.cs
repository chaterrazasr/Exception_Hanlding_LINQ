using System;
using System.Collections.Generic;
using System.IO;

namespace Exception_Handling_LINQ
{
    public static class ProcessText
    {
        public static string ReadTextFile(string filePath)
        {
            try
            {
                return File.ReadAllText(filePath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (IOException)
            {
                Console.WriteLine("Error reading the file.");
            }
            return null;
        }
    }
}
