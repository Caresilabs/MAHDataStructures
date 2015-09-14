using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class ExerciseA
    {
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
            int removedAge = table.Get("Tim");

            Console.WriteLine("Tim's age is( Hint: it's removed ): " + removedAge);
        }
    }
}
