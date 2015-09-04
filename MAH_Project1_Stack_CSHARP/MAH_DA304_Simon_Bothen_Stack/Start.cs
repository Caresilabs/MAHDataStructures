/**

Simon Bothén
DA304A VT 2015

**/

using System;

namespace MAH_DA304_Simon_Bothen_Stack
{
    class Start
    {
        /// <summary>
        /// This is the start point!
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            UppgA uppgA = new UppgA();

            Console.WriteLine("Press the 'anykey' to continue to Uppgift B");
            Console.ReadKey();
            Console.Clear();

            UppgB uppgB = new UppgB();

            Console.Clear();
            Console.WriteLine("Thank you for your time! // Simon B");
            Console.ReadLine();
        }
    }
}
