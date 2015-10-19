/*
*   Simon Bothén
*   DA304A HT15
*/

using System;

namespace MAH_Project3_BST_CSHARP
{
    /// <summary>
    /// Main class for testing the @BinarySearchTree
    /// </summary>
    class Program
    {
        /// <summary>
        /// Runs a basic test of a Binary Search Tree
        /// </summary>
        static void Main(string[] args)
        {
            // ==== Assign ==== //
            BinarySearchTree<int> bTree = new BinarySearchTree<int>();

            // ==== Act ==== //
            {
                // Insert
                bTree.Insert(50);
                bTree.Insert(30);
                bTree.Insert(70);
                bTree.Insert(15);
                bTree.Insert(45);
                bTree.Insert(55);
                bTree.Insert(85);
                bTree.Insert(19);
                bTree.Insert(75);
                bTree.Insert(77);
                bTree.Insert(17);

                // Remove
                bTree.Remove(85);
                bTree.Remove(70);
            }

            // ==== Assert ==== //
            {
                Console.WriteLine("Does it contain 55: " + bTree.Contains(55));

                // Draw Tree
                Console.WriteLine("\nDisplay the tree:");
                Console.WriteLine(bTree.Display());
                PrintOrdered(bTree);
            }

            // Wait for input before closing.
            Console.ReadLine();
        }

        private static void PrintOrdered(BinarySearchTree<int> bTree)
        {
            // We get the ordered list and display it.
            var orderedList = bTree.InorderTraversal();
            {
                foreach (var item in orderedList)
                {
                    Console.Write(item.ToString() + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
