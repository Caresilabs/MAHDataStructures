/*
*   Simon Bothén
*   DA304A HT15
*/

using System;
using System.Collections.Generic;

namespace MAH_Project3_BST_CSHARP
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T> where T : IComparable
    {
        /// <summary>
        /// 
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="value"></param>
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
        /// 
        /// </summary>
        /// <param name="value"></param>
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
        /// 
        /// </summary>
        /// <returns></returns>
        public ICollection<T> InorderTraversal()
        {
            List<T> list = new List<T>();
            Root.InorderTraversal(list);
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ICollection<T> InorderTraversal(T value)
        {
            List<T> list = new List<T>();
            Root.FindValue(value).InorderTraversal(list);
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            return Root.FindValue(value).Type == TreeNode.NodeType.Node;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Display()
        {
            return Root.Display();
        }

        /// <summary>
        /// 
        /// </summary>
        private class TreeNode
        {
            /// <summary>
            /// 
            /// </summary>
            public enum NodeType
            {
                Node, Leaf
            }

            /// <summary>
            /// 
            /// </summary>
            public TreeNode Left { get; private set; }

            /// <summary>
            /// 
            /// </summary>
            public TreeNode Right { get; private set; }

            /// <summary>
            /// 
            /// </summary>
            public NodeType Type { get; private set; }

            /// <summary>
            /// 
            /// </summary>
            public T Data { get; private set; }

            public TreeNode()
            {
                this.Type = NodeType.Leaf;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="value"></param>
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

            public void Set(TreeNode other)
            {
                this.Left = other.Left;
                this.Right = other.Right;
                this.Type = other.Type;
                this.Data = other.Data;
            }

            /// <summary>
            /// 
            /// </summary>
            public void TransformToLeaf()
            {
                this.Type = NodeType.Leaf;
                this.Left = null;
                this.Right = null;
                this.Data = default(T);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
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
                else // We know for sure that Left is the only one left. No need to do: "else if (value.IsLessThan(Data))"
                {
                    return Left.FindValue(value);
                }
            }

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
            /// 
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
            /// 
            /// </summary>
            /// <returns></returns>
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

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool HasChildrens()
            {
                if (Type == NodeType.Leaf) return false;
                return Left.Type != NodeType.Leaf || Right.Type != NodeType.Leaf;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsLeaf()
            {
                return Type == NodeType.Leaf;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="list"></param>
            public void InorderTraversal(ICollection<T> list)
            {
                if (IsLeaf())
                    return;

                Left.InorderTraversal(list);

                list.Add(Data);

                Right.InorderTraversal(list);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
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
    /// Used to compare two values of Type T; value '<' other is not supported.
    /// </summary>
    public static class BinarySearchTreeExtensions
    {
        public static bool IsGreaterThan<T>(this T value, T other) where T : IComparable
        {
            return value.CompareTo(other) > 0;
        }

        public static bool IsLessThan<T>(this T value, T other) where T : IComparable
        {
            return value.CompareTo(other) < 0;
        }
    }
}
