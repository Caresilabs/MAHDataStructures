/*
*   Simon Bothén
*   DA304A HT15
*/

using System;

namespace MAH_Project3_BST_CSHARP
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        static void Main(string[] args)
        {
            // Assign
            BinarySearchTree<int> bTree = new BinarySearchTree<int>();

            // Act
            //bTree.Insert(5);
            bTree.Insert(88);
           /// bTree.Insert(2);
            bTree.Insert(33);
            //bTree.Insert(123);

            // Draw Tree
            Console.WriteLine(bTree.Display());

            // We get the ordered list and display it.
            var orderedList = bTree.InorderTraversal();
            {
                foreach (var item in orderedList)
                {
                    Console.Write(item.ToString() + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Does it contain 88: " + bTree.Contains(88));

            Console.WriteLine("Removing 88");
            bTree.Remove(88);

            // Assert
            Console.WriteLine("Does it contain 88: " + bTree.Contains(88));
            Console.WriteLine(bTree.Display());

            // Wait for input before closing.
            Console.ReadLine();
        }
    }
}
