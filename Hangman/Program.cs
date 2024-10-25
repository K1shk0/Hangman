using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Velkommen til Hangman!");
            //Her har jeg deklareret et heltalsvariabl kaldet for "lives" og den sættes til 7 så spilleren har 7 liv/hjerter.
            int lives = 7;
            //Her variablen "WordToGuess" gemmer ordet som spilleren skal gætte. Den initialiseres ved at kalde PickWord()-metoden, som tilfældigt vælger et ord fra en liste.
            string wordToGuess = PickWord();
            //GuessWord er et array af tegn, som i starten består af understreger og de understreger repræsenter et bogstav i ordet.
            //new string('_', wordToGuess.Length) opretter en string af understreger af samme længde som det ord, der skal gættes.
            //ToCharArray(); konverterer string til et tegn-array, så det kan ændres.
            char[] guessedWord = new string('_', wordToGuess.Length).ToCharArray();

            while (lives > 0 && new string(guessedWord) != wordToGuess)
            {
                Console.Clear();
                Console.WriteLine($"Liv tilbage: {lives}");
                Console.WriteLine($"Ordet: {new string(guessedWord)}");

                Console.WriteLine("Gæt et bogstav eller ord:");
                //inputtet læses som en string og konverteres til små bogstaver for at sikre, at store og små bogstaver behandles ens.
                string input = Console.ReadLine().ToLower();

                    
                if (input.Length > 1)
                {
                    if (input == wordToGuess)
                    {
                        Console.WriteLine("Tillykke! Du gættede ordet!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Forkert ord! Du mister et liv.");
                        lives--;
                    }
                }
                
                else
                {
                    //Tager det første tegn i inputtet som det gættede bogstav
                    char guessedLetter = input[0];
                    //En flag-variable, der holder styr på om gættet var korrekt
                    bool correctGuess = false;

                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuess[i] == guessedLetter)
                        {
                            guessedWord[i] = guessedLetter;
                            correctGuess = true;
                        }
                    }

                    if (!correctGuess)
                    {
                        Console.WriteLine("Forkert bogstav! Du mister et liv.");
                        lives--;
                    }
                }
            }

            if (new string(guessedWord) == wordToGuess)
                Console.WriteLine("Du gættede hele ordet rigtigt! Ordet var: " + wordToGuess);
            else
                Console.WriteLine($"Du har mistet alle dine liv. Ordet var: {wordToGuess}");

            Console.ReadKey();
        }

        
        static string PickWord()
        {
            //Array string, det er her vi sætte vores ord.
            string[] words = {"programmering", "software", "spil", "hangman", "univers", "galakse", "rumskib", "astronaut", "vulkan", "flyvemaskine", "regnbue", "chokolade", "pingvin", "kænguru", "cykel", "solsikke"};
            //Initialiserer en tilfældighedsgenerator.
            Random random = new Random();
            //Vælger et tilfældigt indeks mellem 0 og antallet af ord på listen, og det tilsvarende ord returneres
            return words[random.Next(words.Length)];
        }
    }
}
