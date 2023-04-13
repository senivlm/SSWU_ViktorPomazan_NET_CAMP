using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_2
{
    internal static class Printer
    {
        public static void PrintEmails(string str, string[] validEmails, string[] invalidEmails)
        {
            Console.WriteLine("Valid Emails: ");
            foreach (string email in validEmails)
            {
                Console.WriteLine(email);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Invalid Emails: ");
            foreach (string email in invalidEmails)
            {
                Console.WriteLine(email);
            }
        }
    }
}
