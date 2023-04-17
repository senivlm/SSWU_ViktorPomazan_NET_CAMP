using FindTextInBrackets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_1
{
    public static class Printer
    {
        public static void PrintEng()
        {
            string englishText = @"This sentence (has some brackets).
                                                Another sentences have ( information in brackets)?  
    \n Next sentence, unfortunatelly, without brackets.
                    Sentence 4 with (brakcets)!";

            TextManipulator manipulator = new TextManipulator(englishText);
            List<string> sentencesWithBrackets = manipulator.GetSentencesWithBrackets();

            Console.WriteLine("Sentences containing brackets:");
            foreach (string sentence in sentencesWithBrackets)
            {
                Console.WriteLine(sentence);
            }
        }
        public static void PrintUkr()
        {
            string ukrainianText = @"Це речення (має кілька скобочок).
                                                Інші речення мають ( інформацію в скобочках)!  
    \n Наступне речення, нажаль, не має скобочок.
                   А ось четверте має (скобочку)!";

            TextManipulator processor = new TextManipulator(ukrainianText);
            List<string> sentencesWithBrackets = processor.GetSentencesWithBrackets();

            Console.WriteLine("Речення, що мають скобочки");
            foreach (string sentence in sentencesWithBrackets)
            {
                Console.WriteLine(sentence);
            }
        }
    }
}
