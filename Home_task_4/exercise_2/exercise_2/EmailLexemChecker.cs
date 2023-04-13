using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_2
{
    internal static class EmailLexemChecker
    {
        public static bool CheckLexem(string beforeAddressSign, string afterAddressSign)
        {
            if (beforeAddressSign.Contains("..") || afterAddressSign.Contains(".."))
            {
                return false;
            }
            if (afterAddressSign.StartsWith(".") || afterAddressSign.EndsWith("."))
            {
                return false;
            }
            for (int i = 0; i < beforeAddressSign.Length; i++)
            {
                char c = beforeAddressSign[i];
                if (!char.IsLetterOrDigit(c) && c != '!' && c != '#' && c != '$' && c != '%' && c != '&'
                    && c != '\'' && c != '*' && c != '+' && c != '-' && c != '/' && c != '=' && c != '?' && c != '^'
                    && c != '_' && c != '`' && c != '{' && c != '|' && c != '}' && c != '~' && c != '.')
                {
                    return false;
                }
            }
            string[] domainParts = afterAddressSign.Split('.');
            foreach (string part in domainParts)
            {
                if (part.Length == 0)
                {
                    return false;
                }
                foreach (char c in part)
                {
                    if (!char.IsLetter(c))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
