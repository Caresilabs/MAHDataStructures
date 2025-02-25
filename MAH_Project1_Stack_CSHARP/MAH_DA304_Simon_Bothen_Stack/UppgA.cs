﻿/**

Simon Bothén
DA304A VT 2015

**/

using System;

namespace MAH_DA304_Simon_Bothen_Stack
{
    /// <summary>
    /// This is the first exercise which is shows a basic stack in work. It basically prints some values to the screen for confirmation 
    /// that the stack is indeed working.
    /// </summary>
    class UppgA
    {
        public UppgA()
        {
            Console.WriteLine("Starting UppgiftA!\n");

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

            Console.WriteLine("\nEnding UppgiftA!\n");
        }
    }
}
