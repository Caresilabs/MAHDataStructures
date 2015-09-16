/*
    Simon Bothén
    DA304A HT15
*/

using System;

namespace HashTable
{
    /// <summary>
    /// Main program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main function that get called when you execute the program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("============ Exercise A ===========");
            ExerciseA exA = new ExerciseA();
            Console.WriteLine("Press the 'any' key to continue.");
            Console.Read();
            Console.Clear();

            Console.WriteLine("============ Exercise B ===========");
            ExerciseB exB = new ExerciseB();
            Console.WriteLine("Bye! Have a nice day :)");
            Console.Read();
        }
    }
}
