/**

Simon Bothén
DA304A VT 2015

**/

using System;

namespace MAH_DA304_Simon_Bothen_Stack
{
    class UppgA
    {
        public UppgA()
        {
            Console.WriteLine("Starting UppgiftA! ");

            Stack<int> myStack = new Stack<int>();

            myStack.Push(2);
            myStack.Push(4);
            myStack.Push(8);
            myStack.Push(16);
            myStack.Push(32);

            Console.WriteLine("Pop: -> " + myStack.Pop());
            Console.WriteLine("Now peek -> " + myStack.Peek());

            Console.WriteLine("Push '420'");
            myStack.Push(420);

            Console.WriteLine("Peek again after new push -> " + myStack.Peek());

            Console.WriteLine("Ending UppgiftA!\n");
        }
    }
}
