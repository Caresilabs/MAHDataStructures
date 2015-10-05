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
                // The Tree:
                //
                //     88
                //  33    122
                // 12    90
                //

                bTree.Insert(88);
                bTree.Insert(33);
                bTree.Insert(122);
                bTree.Insert(90);
                bTree.Insert(12);

                // Draw Tree
                Console.WriteLine("\nDisplay the tree:");
                Console.WriteLine(bTree.Display());
                PrintOrdered(bTree);

                Console.WriteLine("Does it contain 88: " + bTree.Contains(88) + "\n");

                Console.WriteLine("Removing 88");
                bTree.Remove(88);

                Console.WriteLine("Removing 33");
                bTree.Remove(33);

            }

            // ==== Assert ==== //
            {
                Console.WriteLine("Does it contain 88: " + bTree.Contains(88));

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
