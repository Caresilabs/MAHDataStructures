/**

Simon Bothén
DA304A VT 2015

**/

using System;

namespace MAH_DA304_Simon_Bothen_Stack
{

    /// <summary>
    /// This is the stack class, which handles Pop, Push and other helper methods.
    /// </summary>
    class Stack<T>
    {
        /// <summary>
        /// Node class is a container for the stack data, and a pointer to the next node.
        /// </summary>
        private class Node
        {
            public Node Next { get; private set; }
            public T Data { get; private set; }

            public Node(T data, Node next)
            {
                this.Data = data;
                this.Next = next;
            }
        }

        /// <summary>
        /// Head node which is on the very top of the stack.
        /// </summary>
        private Node Head { get; set; }
        
        /// <summary>
        /// This is how many items the stack contains
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Push is used to add user data highest up on the stack
        /// </summary>
        /// <param name="data">The data of type T you want to push to the stack</param>
        public void Push(T data)
        {
            var newNode = new Node(data, Head);
            Head = newNode;
            ++Count;
        }

        /// <summary>
        /// Pop removes the top node and returns it data.
        /// </summary>
        /// <returns>Popped data of Type T</returns>
        public T Pop()
        {
            if (!IsEmpty())
            {
                var popped = Head;
                T poppedData = popped.Data;
                Head = popped.Next;
                --Count;
                return poppedData;
            }

            throw new Exception("Stack underflow");
        }

        /// <summary>
        /// Peek returns a stacks head data WITHOUT modifying the stack.
        /// </summary>
        /// <returns>The head data</returns>
        public T Peek()
        {
            return Head.Data;
        }

        /// <summary>
        /// Check if the stack is empty
        /// </summary>
        /// <returns>Whenever the stack is empty</returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }

    }
}
