using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAH_Project3_BST_CSHARP
{
    class Program
    {
        static void Main(string[] args)
        {
            // Assign
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            var rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                int value = rnd.Next(-10, 10);
                if (!bst.Contains(value))
                {
                    Console.Write(value + ",");
                    bst.Insert(value);
                }

            }
            Console.WriteLine();

            Console.WriteLine(bst.Display());

            bst.InorderTraversal();

            Console.ReadLine();
        }
    }
}
