using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace exercice_3
{
    public class StringIterator
    {
        private string _text;
        private IEnumerable<string> _uniqueWords;

       
        public StringIterator(string text)
        {
            _text = (string)text.Clone();
        }
        public IEnumerable<string> UniqueWords
        {
            get { return new List<string>(_uniqueWords); }
        }
        public IEnumerable<string> GetUniqueWords()
        {
            HashSet<string> uniqueWords = new HashSet<string>();
            string[] words = _text.Split(new[] { ' ', ',', '.', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (uniqueWords.Add(word))
                {
                    yield return word;
                }
            }
            _uniqueWords = uniqueWords;
        }
    }
}
