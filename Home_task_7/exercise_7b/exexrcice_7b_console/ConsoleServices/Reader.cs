using exercise_7b.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exexrcice_7b_console
{
    internal class Reader: IReader
    {
        public int ReadValue(string message)
        {
            int value;
            bool isValidInput = false;
            do
            {
                Console.Write(message);
                string input = Console.ReadLine();
                isValidInput = Int32.TryParse(input, out value) && value > 0;
                if (!isValidInput)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                }
            } while (!isValidInput);
            return value;
        }
    }
}
