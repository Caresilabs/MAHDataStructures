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

                Root.Add(value);
                ++Count;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); //"Value already exists");
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

        public void Display()
        {
            //if (Root != null)
                //Root.Display();
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

            public void Add(T value)
            {
                TreeNode searchedNode = FindValue(value);

                searchedNode.Set(value);

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
