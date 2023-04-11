using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace exercise_2
{
    internal class StringManipulator
    {//Молодець!
        public static int? FindSecondSubstringIndex(string text, string substring)
        {
            int firstIndex = text.IndexOf(substring);
            if (firstIndex != -1)
            {
                int secondIndex = text.IndexOf(substring, firstIndex + 1);
                if (secondIndex != -1)
                {
                    return secondIndex;
                }
            }
            return null;
        }

        public static int FIndCountWordsStartingWithCapitalLetter(string text)
        {
            int count = 0;
            string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (Char.IsUpper(word[0]))
                {
                    count++;
                }
            }
            return count;
        }

        public static string ReplaceWordsWithDoubleLetters(string text, string replacement)
        {// Прочитаємо разом регулярний вираз...
            Regex regex = new Regex(@"\b\w*(\w)\1\w*\b");
            return regex.Replace(text, replacement);
        }
    }

}
