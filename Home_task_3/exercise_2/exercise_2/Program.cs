using System;

namespace exercise_2
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter the text: ");
            string text = Console.ReadLine();

            Console.Write("Enter the substring: ");
            string substring = Console.ReadLine();

            Console.Write("Enter the replacement: ");
            string replacement = Console.ReadLine();

            int? secondSubstringIndex = StringManipulator.FindSecondSubstringIndex(text, substring);
            if (secondSubstringIndex != null)
            {
                Console.WriteLine("Second '" + substring + "' found at index " + secondSubstringIndex);
            }
            else
            {
                Console.WriteLine("Second '" + substring + "' not found");
            }

            int count = StringManipulator.FIndCountWordsStartingWithCapitalLetter(text);
            Console.WriteLine("Number of words starting with a capital letter: " + count);

            string replacedText = StringManipulator.ReplaceWordsWithDoubleLetters(text, replacement);
            Console.WriteLine("Text with words containing double letters replaced: " + replacedText);
        }
    }
}