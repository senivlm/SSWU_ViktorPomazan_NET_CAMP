using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice_3
{
    public static class Printer
    {
        public static void Print()
        {
            string text = "The sun was shining bright, oh so bright, sweetly, oh so sweetly.";
            StringIterator iterator = new StringIterator(text);
            List<string> words = iterator.GetUniqueWords().ToList();
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
