/*
    Simon Bothén
    DA304A HT15
*/

using System;

namespace HashTable
{
    /// <summary>
    /// Basically a simple test to show of that my HashTable is working 100%.
    /// </summary>
    class ExerciseA
    {
        /// <summary>
        /// Default constructor run the actual test.
        /// </summary>
        public ExerciseA()
        {
            var table = new HashTable<string, int>(15);

            table.Put("Simon", 19);
            table.Put("Emma", 18);
            table.Put("Tim", 21);
            table.Put("Putin", 13);
            table.Put("Obama", 25);

            int putinsAge = table.Get("Putin");
            Console.WriteLine("Putin's age is: " + putinsAge);

            table.Remove("Tim");

            if (!table.Contains("Tim"))
            {
                Console.WriteLine("Tim's age is removed!");
            }

            Console.WriteLine("Max list size in the HashTable (should be low!): " + table.GetMaxCurrentPositionCollisions());
        }
    }
}
