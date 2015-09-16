/*
    Simon Bothén
    DA304A HT15
*/
using System;

namespace HashTable
{
    /// <summary>
    /// This is a simple translator using a HashTable.
    /// OBS! This module translates word by word so if you translate a whole sentence you can be 99% sure that it's not grammatically correct.
    /// </summary>
    class ExerciseB
    {
        /// <summary>
        /// Default constructor run the actual test.
        /// </summary>
        public ExerciseB()
        {
            var dictionary = new HashTable<string, string>();

            // Print
            PrintOptions();
           
            while (true)
            {
                string input = Console.ReadLine().Replace(".", "");
                
                switch (input)
                {
                    case "1":
                        // Change/Put new translation in the HashTable.
                        Console.Write("\tEnter the word: ");
                        string key = Console.ReadLine();
                        Console.Write("\tEnter the translation: ");
                        string value = Console.ReadLine();
                        dictionary.Put(key, value);
                        break;
                    case "2":
                        // Translate word by word
                        Console.WriteLine("\tPlease enter a sentence you want to translate:");
                        string[] toTranslate = Console.ReadLine().Split(' ', '.', '!', '?');
                        Console.Write("\t=> ");
                        foreach (string word in toTranslate)
                        {
                            string translation = dictionary.Get(word);
                            Console.Write((translation == default(string) ? word : translation) + " ");
                        }
                        Console.WriteLine();
                        break;
                    case "3":
                        return;
                    default:
                        continue;
                }

                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
                Console.Clear();
                PrintOptions();
             
            }
        }

        /// <summary>
        /// Prints the options
        /// </summary>
        public void PrintOptions()
        {
            Console.WriteLine("Welcome to Super Mega Translator 2015 Simulator!");
            Console.WriteLine("[Disclaimer: This translator is not reliable in any way. Therefore only use it to get an grade.]\n\n");

            Console.WriteLine("\tChoose an option:\n\t1. Set/Change a word\n\t2. Translate sentence\n\t3. Exit\n");
            Console.Write("# ");
        }
    }
}
