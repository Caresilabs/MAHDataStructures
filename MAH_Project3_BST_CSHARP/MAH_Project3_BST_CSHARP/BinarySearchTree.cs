using MAH_Project3_BST_CSHARP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAH_Project3_BST_CSHARP
{
    public class BinarySearchTree<T> where T : IComparable
    {
        private TreeNode Root { get; set; }
        private int Count { get; set; }

        public BinarySearchTree()
        {

        }

        public void Insert(T value)
        {
            try
            {
                if (Root == null)
                {
                    Root = new TreeNode(null, value);
                }

                TreeNode node = Root.FindValue(value);
                if (node != null)
                    node.Set(value);

                ++Count;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); //"Value already exists");
            }
        }

        public void Remove(T value)
        {
            if (Root != null)
            {
                var toRemove = Root.FindValue(value);
                if (toRemove != null)
                    toRemove.Remove();
            }
        }

        public bool Contains(T value)
        {
            if (Root != null)
            {
                return Root.FindValue(value).Type == TreeNode.NodeType.Node;
            }
            return false;
        }

        public string Display()
        {
            if (Root != null)
                return Root.Display(Root);
            return "";
        }

        private class TreeNode
        {
            public enum NodeType
            {
                Node, Leaf
            }

            public TreeNode Left { get; private set; }
            public TreeNode Right { get; private set; }
            public TreeNode Parent { get; private set; }
            public NodeType Type { get; private set; }

            public T Data { get; private set; }

            public TreeNode(TreeNode parent)
            {
                this.Parent = Parent;
                this.Type = NodeType.Leaf;
            }

            public TreeNode(TreeNode parent, T data)
            {
                this.Left = new TreeNode(this);
                this.Right = new TreeNode(this);
                this.Parent = parent;
                this.Type = NodeType.Node;
            }
            
            public void Set(T value)
            {
                if (Type == NodeType.Leaf)
                {
                    this.Left = new TreeNode(this);
                    this.Right = new TreeNode(this);
                    this.Type = NodeType.Node;
                }

                this.Data = value;
            }

            public void TransformToLeaf()
            {
                this.Type = NodeType.Leaf;
                this.Left = null;
                this.Right = null;
                this.Data = default(T);
            }

            public TreeNode FindValue(T value)
            {
                if (Type == NodeType.Leaf)
                {
                    return this;
                }

                if (value.Equals(Data))
                {
                    return this;
                }
                else if (value.IsGreaterThan(Data))
                {
                    return Right.FindValue(value);
                }
                else if (value.IsLessThan(Data))
                {
                    return Left.FindValue(value);
                }

                return null;
            }

            private TreeNode FindParent(T value, ref TreeNode parent) // Not out?
            {
                var searchedNode = FindValue(value);
                parent = searchedNode.Parent;
                return searchedNode;
            }

            public void Add(T value)
            {
             

            }

            public void Remove()
            {
                // The value isnt found, do nothing.
                if (IsLeaf())
                    return;

                // Case 1
                if (!HasChildrens())
                {
                    if (Parent != null)
                        TransformToLeaf();

                    return;
                }

                // Case 3: 1 children
                if (!Left.IsLeaf() && !Right.IsLeaf())
                {

                }
            }
            

            public bool HasChildrens()
            {
                if (Type == NodeType.Leaf) return false;
                return Left.Type != NodeType.Leaf || Right.Type != NodeType.Leaf;
            }

            public bool IsLeaf()
            {
                return Type == NodeType.Leaf;
            }

            public string Display(TreeNode node)
            {
                if (node.Type == NodeType.Leaf)
                    return "empty";

                if (!HasChildrens())
                    return node.Data.ToString();

                if ((!node.Left.IsLeaf()) && (node.Right.IsLeaf()))
                    return "" + node.Data + "(" + Display(node.Left) + ", _)";

                if ((!node.Right.IsLeaf()) && (node.Left.IsLeaf()))
                    return "" + node.Data + "(_, " + Display(node.Right) + ")";

                return node.Data + "(" + Display(node.Left) + ", " + Display(node.Right) + ")";
            }

          
        }
    }

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
