using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class PrintHelper
    {
        public static void PrintWord(string printableword)
        {
            var word = GetFormatedPrintableWord(printableword);
            Console.WriteLine("------------------");
            Console.WriteLine(word);
            Console.WriteLine("------------------");
            Console.WriteLine();
        }

        public static void PrintResult(int retryCount, List<string> usedLetters)
        {
            Console.WriteLine($"Retry count: {retryCount}");

            Console.WriteLine($"Used letters: {string.Join(",", usedLetters)}");
        }
        static string GetFormatedPrintableWord(string printableName)
        {
            return string.Join(" ", printableName.ToCharArray());
        }
    }
}
