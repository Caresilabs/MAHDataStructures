/*
*   Simon Bothén
*   DA304A HT15
*/

using System;
using System.Collections.Generic;

namespace MAH_Project3_BST_CSHARP
{
    /// <summary>
    /// This is a Binary Search Tree. See https://en.wikipedia.org/wiki/Binary_search_tree
    /// </summary>
    /// <typeparam name="T">The type of data you want to store. Must be a ICompareable</typeparam>
    public class BinarySearchTree<T> where T : IComparable
    {
        /// <summary>
        /// The total amount of nodes, excluding leafs.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// The root node of the tree.
        /// </summary>
        private TreeNode Root { get; set; }

        /// <summary>
        /// Creates a Binary Search Tree. A default root node is created.
        /// </summary>
        public BinarySearchTree()
        {
            Root = new TreeNode();
        }

        /// <summary>
        /// Inserts a value to the tree.
        /// </summary>
        /// <param name="value">The vaue to store</param>
        public void Insert(T value)
        {
            try
            {
                TreeNode node = Root.FindValue(value);

                // If value already exists
                if (node.Type == TreeNode.NodeType.Node)
                    throw new Exception("Value already exists");

                node.Set(value);
                ++Count;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Removes the value from the tree.
        /// </summary>
        /// <param name="value">The value to remove.</param>
        public void Remove(T value)
        {
            TreeNode parent = null;
            var toRemove = Root.FindValue(value, ref parent);
            if (toRemove.Type == TreeNode.NodeType.Node)
            {
                toRemove.Remove(parent);
                --Count;
            }
        }

        /// <summary>
        /// Does an InorderTraversal on the whole tree.
        /// </summary>
        /// <returns>An ordered collection of all data stored.</returns>
        public ICollection<T> InorderTraversal()
        {
            List<T> list = new List<T>();
            Root.InorderTraversal(list);
            return list;
        }

        /// <summary>
        /// Does an InorderTraversal on the node with the value.
        /// </summary>
        /// <returns>An ordered collection of all data stored.</returns>
        public ICollection<T> InorderTraversal(T value)
        {
            List<T> list = new List<T>();
            Root.FindValue(value).InorderTraversal(list);
            return list;
        }

        /// <summary>
        /// Checks if a value was found in the tree.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <returns>If the value was found in the tree.</returns>
        public bool Contains(T value)
        {
            return Root.FindValue(value).Type == TreeNode.NodeType.Node;
        }

        /// <summary>
        /// Displays the whole tree. Returns a string containing the tree structure.
        /// </summary>
        public string Display()
        {
            return Root.Display();
        }

        /// <summary>
        /// This is the Binary Search Tree Node. It handles most of the job and it represent a node in the tree. However it is also used as a Leaf.
        /// </summary>
        private class TreeNode
        {
            /// <summary>
            /// Different types of nodes.
            /// </summary>
            public enum NodeType
            {
                Node, Leaf
            }

            /// <summary>
            /// The left children node.
            /// </summary>
            public TreeNode Left { get; private set; }

            /// <summary>
            /// The right children node.
            /// </summary>
            public TreeNode Right { get; private set; }

            /// <summary>
            /// The node type.
            /// </summary>
            public NodeType Type { get; private set; }

            /// <summary>
            /// The data to store in the node.
            /// </summary>
            public T Data { get; private set; }

            /// <summary>
            /// Creates a node and make it a leaf.
            /// </summary>
            public TreeNode()
            {
                this.Type = NodeType.Leaf;
            }

            /// <summary>
            /// Change the value of the node.
            /// </summary>
            /// <param name="value">The value to set</param>
            public void Set(T value)
            {
                // If we are a leaf, then make it a node.
                if (Type == NodeType.Leaf)
                {
                    this.Left = new TreeNode();
                    this.Right = new TreeNode();
                    this.Type = NodeType.Node;
                }

                this.Data = value;
            }

            /// <summary>
            /// Clone another nodes data.
            /// </summary>
            /// <param name="other"></param>
            public void Set(TreeNode other)
            {
                this.Left = other.Left;
                this.Right = other.Right;
                this.Type = other.Type;
                this.Data = other.Data;
            }

            /// <summary>
            /// Make this node a leaf. Also detaches it's children.
            /// </summary>
            public void TransformToLeaf()
            {
                this.Type = NodeType.Leaf;
                this.Left = null;
                this.Right = null;
                this.Data = default(T);
            }

            /// <summary>
            /// Searches for the input value.
            /// </summary>
            /// <param name="value">The value to search for.</param>
            public TreeNode FindValue(T value)
            {
                if (Type == NodeType.Leaf)
                    return this;

                if (value.Equals(Data))
                {
                    return this;
                }
                else if (value.IsGreaterThan(Data))
                {
                    return Right.FindValue(value);
                }
                else    // We know for sure that Left is the only one left. No need to do: "else if (value.IsLessThan(Data))"
                {
                    return Left.FindValue(value);
                }
            }

            /// <summary>
            /// Searches for the input value.
            /// </summary>
            /// <param name="value">The value to search for.</param>
            /// <param name="parent">The found node's parent.</param>
            public TreeNode FindValue(T value, ref TreeNode parent)
            {
                if (Type == NodeType.Leaf)
                    return this;

                if (value.Equals(Data))
                {
                    return this;
                }
                else if (value.IsGreaterThan(Data))
                {
                    parent = this;
                    return Right.FindValue(value, ref parent);
                }
                else // We know for sure that Left is the only one left. No need to do: "else if (value.IsLessThan(Data))"
                {
                    parent = this;
                    return Left.FindValue(value, ref parent);
                }
            }

            /// <summary>
            /// Remove the node. Must input the node's parent.
            /// </summary>
            public void Remove(TreeNode parent)
            {
                // The value is not found, do nothing.
                if (IsLeaf())
                    return;

                // Case 1: 0 Children: Just remove
                if (!HasChildrens())
                {
                    TransformToLeaf();
                    return;
                }

                // Case 3: 2 children: Swap with LeftMostNodeOnRight
                if (!Left.IsLeaf() && !Right.IsLeaf())
                {
                    TreeNode toSwapParent = null;
                    TreeNode toSwap = LeftMostNodeOnRight(ref toSwapParent);

                    Set(toSwap.Data);
                    // TODO
                    if (toSwap.Right.Type == NodeType.Node)
                    {
                        toSwapParent.Left = toSwap.Right;
                    }

                    toSwap.TransformToLeaf();
                    return;
                }

                // Case 2: 1 children: Swap with child then make delete value to a Leaf
                if (!Left.IsLeaf())
                {
                    if (parent == null)
                    {
                        Set(Left);
                        return;
                    }

                    if (parent.Left == this)
                        parent.Left = Left;
                    else if (parent.Right == this)
                        parent.Right = Left;
                }
                else if (!Right.IsLeaf())
                {
                    if (parent == null)
                    {
                        Set(Right);
                        return;
                    }

                    if (parent.Left == this)
                        parent.Left = Right;
                    else if (parent.Right == this)
                        parent.Right = Right;
                }
            }

            /// <summary>
            /// Get the Left Most Node on the right side of this node.
            /// </summary>
            public TreeNode LeftMostNodeOnRight(ref TreeNode parent)
            {
                parent = this;
                var nodeToDelete = Right;

                while (!nodeToDelete.Left.IsLeaf())
                {
                    parent = nodeToDelete;
                    nodeToDelete = nodeToDelete.Left;
                }

                return nodeToDelete;
            }

            /// <returns>If the node has any children.</returns>
            public bool HasChildrens()
            {
                if (Type == NodeType.Leaf) return false;
                return Left.Type != NodeType.Leaf || Right.Type != NodeType.Leaf;
            }

            /// <returns>Is the node a leaf.</returns>
            public bool IsLeaf()
            {
                return Type == NodeType.Leaf;
            }

            /// <summary>
            /// Do an inorderTraversal in this node and save it's result in a list.
            /// </summary>
            /// <param name="list">An ordered list of all data.</param>
            public void InorderTraversal(ICollection<T> list)
            {
                if (IsLeaf())
                    return;

                Left.InorderTraversal(list);

                list.Add(Data);

                Right.InorderTraversal(list);
            }

            /// <summary>
            /// Gets a string of this nodes structure.
            /// </summary>
            /// <returns>A string of this nodes structure and it's substructure.</returns>
            public string Display()
            {
                if (Type == NodeType.Leaf)
                    return "empty";

                if (!HasChildrens())
                    return Data.ToString();

                if ((!Left.IsLeaf()) && (Right.IsLeaf()))
                    return Data + "(" + Left.Display() + ", _)";

                if ((!Right.IsLeaf()) && (Left.IsLeaf()))
                    return Data + "(_, " + Right.Display() + ")";

                return Data + "(" + Left.Display() + ", " + Right.Display() + ")";
            }
        }
    }

    /// <summary>
    /// Used to compare two values of Type T; value '< >' other is not supported.
    /// </summary>
    public static class BinarySearchTreeExtensions
    {
        /// <summary>
        /// If the value is larger than the other.
        /// </summary>
        public static bool IsGreaterThan<T>(this T value, T other) where T : IComparable
        {
            return value.CompareTo(other) > 0;
        }

        /// <summary>
        /// If the value is less than the other.
        /// </summary>
        public static bool IsLessThan<T>(this T value, T other) where T : IComparable
        {
            return value.CompareTo(other) < 0;
        }
    }
}
