namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int maxNumberOfRetries = 6;
            const string wildCard = "_";

            List<string> usedLetters = new List<string>();
            int retryCount = 0;

            string printableWord = "";
            string,wordToGuess = GetWord();

            //replace letters with placeholder in printable version
            foreach (var letter in wordToGuess)
            {
                printableWord += wildCard;
            }

            PrintHelper.PrintWord(printableWord);

            //foreach (var letter in printableWord)
            //{
            //    Console.Write($"{letter} ");
            //}

            //Console.WriteLine();

            //string letterFromUser;

            //game loop
            while (true)
            {
                string letterFromUser = GetLetterFromUser();

                if (wordToGuess.ToUpper().Contains(letterFromUser.ToUpper()))
                {
                    //convert to char array to use index for replacing letters
                    var charArr = printableWord.ToCharArray();

                    //swap _ to actial letters
                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuess[i].ToString().ToUpper() == letterFromUser.ToUpper())
                        {
                            charArr[i] = letterFromUser.ToUpper()[0];
                        }
                    }
                    //re-assign new value
                    printableWord = String.Join("", charArr);
                }
                else
                {
                    if (!usedLetters.Contains(letterFromUser.ToUpper()))
                    {
                        usedLetters.Add(letterFromUser.ToUpper());
                    }

                    ++retryCount;
                }

                //foreach (var letter in printableWord)
                //{
                //    Console.Write($"{letter} ");
                //}

                PrintHelper.PrintWord(printableWord);

                PrintHelper.PrintResult(retryCount, usedLetters);

                    if (!printableWord.Contains(wildCard))
                    {
                        Console.WriteLine("You won !!!");
                        return;
                    }
                    if (retryCount >= maxNumberOfRetries)
                    {
                        Console.WriteLine("Game over");
                        return; //break could be used too but on this example only
                    }

            }
        }

        static string GetLetterFromUser()
        {
            string letterFromUser;

            //get letter from user
            while (true)
            {
                Console.WriteLine("Please enter a letter");
                letterFromUser = Console.ReadLine();

                if (string.IsNullOrEmpty(letterFromUser))
                {
                    Console.WriteLine("Please enter a letter");
                    continue;
                }
                if (letterFromUser.Length > 1)
                {
                    Console.WriteLine("Please enter only one letter!");
                    continue;
                }
                return letterFromUser;
            }
        }

        static string GetWord()
        {
            string[] words = { "cat", "dog", "bird" };

            Random random = new Random();

            int index = random.Next(words.Length);

            string wordToGuess = words[index];

            return wordToGuess;
        }
    }
}