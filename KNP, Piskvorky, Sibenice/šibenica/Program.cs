using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace šibenica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = LoadWords("Slova_hangman.txt");
            string[] stages = LoadHangmanStages("Hangman_visual.txt");

            if (words.Length == 0 || stages.Length == 0)
            {
                Console.WriteLine("Missing words or hangman visuals. Check your files.");
                return;
            }

            Random rnd = new Random();
            string secretWord = words[rnd.Next(words.Length)].ToLower();
            HashSet<char> guessed = new HashSet<char>();
            int incorrectGuesses = 0;
            int maxIncorrect = stages.Length - 1;

            while (true)
            {
                Console.Clear();
                ShowHangmanStage(stages, incorrectGuesses);
                Console.WriteLine();
                Console.WriteLine("Slovo: " + GetMaskedWord(secretWord, guessed));
                Console.WriteLine("Tipnutá písmena: " + string.Join(" ", guessed));
                Console.WriteLine($"Zbývá pokusů: {maxIncorrect - incorrectGuesses}");

                if (IsWordGuessed(secretWord, guessed))
                {
                    Console.WriteLine("\nGratulace! Uhodl(a) jste slovo!");
                    break;
                }
                if (incorrectGuesses >= maxIncorrect)
                {
                    Console.WriteLine($"\nProhrál(a) jste! Slovo bylo: {secretWord}");
                    break;
                }

                Console.Write("\nZadejte písmeno: ");
                string input = Console.ReadLine()?.ToLower();
                if (string.IsNullOrWhiteSpace(input) || input.Length != 1 || !char.IsLetter(input[0]))
                {
                    Console.WriteLine("Zadejte jedno písmeno.");
                    Console.ReadKey();
                    continue;
                }

                char guess = input[0];
                if (guessed.Contains(guess))
                {
                    Console.WriteLine("Toto písmeno už bylo tipnuto.");
                    Console.ReadKey();
                    continue;
                }

                guessed.Add(guess);
                if (!secretWord.Contains(guess))
                {
                    incorrectGuesses++;
                }
            }
        }

        static string[] LoadWords(string filePath)
        {
            if (!File.Exists(filePath))
                return Array.Empty<string>();
            return File.ReadAllLines(filePath)
                .Select(line => line.Trim())
                .Where(line => !string.IsNullOrEmpty(line))
                .ToArray();
        }

        static string[] LoadHangmanStages(string filePath)
        {
            if (!File.Exists(filePath))
                return Array.Empty<string>();
            string content = File.ReadAllText(filePath);
            return content.Split(new string[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
        }

        static void ShowHangmanStage(string[] stages, int incorrectGuesses)
        {
            // Reverse the index: 0 incorrect = last stage, max incorrect = first stage
            int index = Math.Max(0, stages.Length - 1 - incorrectGuesses);
            Console.WriteLine(stages[index]);
        }

        static string GetMaskedWord(string word, HashSet<char> guessed)
        {
            return string.Concat(word.Select(c => guessed.Contains(c) ? c : '_'));
        }

        static bool IsWordGuessed(string word, HashSet<char> guessed)
        {
            return word.All(c => guessed.Contains(c));
        }
    }
}
