/**

Simon Bothén
DA304A VT 2015

**/

using System;
using System.Text;
using System.Linq;

namespace MAH_DA304_Simon_Bothen_Stack
{
    class UppgB
    {
        private char[] startBrackets = { '{', '(', '<', '[' };
        private char[] endBrackets = { '}', ')', '>', ']' };

        public UppgB()
        {
            Console.WriteLine("Starting UppgiftB! ");

            String inputData;

            Console.WriteLine("Enter text to parse:");
            while (true)
            {
                inputData = Console.ReadLine();
                if (inputData.ToLower() == "exit") break;

                Stack<char> myStack = new Stack<char>();

                StringBuilder errors = new StringBuilder();
                foreach (char c in inputData)
                {
                    if (startBrackets.Contains(c))
                    {
                        myStack.Push(c);
                    }
                    else if (endBrackets.Contains(c))
                    {
                        char previousBracket = myStack.Pop();

                        if (!Match(previousBracket, c))
                        {
                            errors.AppendLine(previousBracket + " doesn't match with " + c);
                        }
                    }
                }

                // If my stack contains an uneven amount 
                if (myStack.Count % 2 == 1)
                {
                    errors.AppendLine("Bracket is missing");
                }


                // Print errors if there is any
                if (errors.Length != 0)
                {
                    Console.WriteLine("Errors: \n" + errors);
                }

                Console.WriteLine("Text parsed...");
                Console.WriteLine("Enter text to parse: (exit to exit)");

            }

            Console.WriteLine("Ending UppgiftB!\n");

        }

        public bool Match(char x, char y)
        {
            if ((x == '(' && y == ')') || (y == '(' && x == ')'))
                return true;
            if ((x == '[' && y == ']') || (y == '[' && x == ']'))
                return true;
            if (x == '{' && y == '}' || (y == '{' && x == '}'))
                return true;
            if (x == '<' && y == '>' || (y == '<' && x == '>'))
                return true;

            return false;
        }
    }
}

