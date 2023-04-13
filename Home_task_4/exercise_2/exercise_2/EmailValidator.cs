using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_2
{
    internal static class EmailValidator
    {
        public static bool IsEmailCorrect(string email)
        {
            if (string.IsNullOrEmpty(email))
            {

                return false;
            }
            if (!(email.Contains('.')))
            {
                return false;
            }

            int Index = email.IndexOf('@');

            if (Index <= 0 || Index == email.Length - 1)
            {
                return false;
            }
            string beforeAddressSign = email.Substring(0, Index);
            string afterAddressSign = email.Substring(Index + 1);
            
            return EmailLexemChecker.CheckLexem(beforeAddressSign, afterAddressSign);
        }
        public static void GetEmails(string str, out string[] validEmails, out string[] invalidEmails)
        {
            List<string> validEmailsList = new List<string>();
            List<string> invalidEmailsList = new List<string>();

            string[] words = str.Split(' ', ',', ';', ':', '\t', '\n');

            foreach (string word in words)
            {
                if (word.Contains("@"))
                {
                    bool isReal = IsEmailCorrect(word);
                    if (isReal)
                    {
                        validEmailsList.Add(word);
                    }
                    else
                    {
                        invalidEmailsList.Add(word);
                    }
                }
            }
            validEmails = validEmailsList.ToArray();
            invalidEmails = invalidEmailsList.ToArray();
        }
    }
}
