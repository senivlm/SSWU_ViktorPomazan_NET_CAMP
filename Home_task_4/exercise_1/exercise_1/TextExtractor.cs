using System.Collections;
using System;
using System.Text;

namespace FindTextInBrackets
{// Текст мав бути колекцією стрічок, яку не можна зливати в одну, за умовою задачі. Це алгоритмічно складніша задача.
    class TextManipulator
    {
        private string _text;
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }
        public TextManipulator(string text)
        {
            _text = text;
        }

        public List<string> GetSentencesWithBrackets()
        {
            List<string> sentences = GetAllSentences();
            List<string> sentencesWithBrackets = new List<string>();

            foreach (string sentence in sentences)
            {
                if (sentence.Contains("(") && sentence.Contains(")")
                    || sentence.Contains("[") && sentence.Contains("]")
                    || sentence.Contains("{") && sentence.Contains("}"))
                {
                    sentencesWithBrackets.Add(sentence);
                }
            }

            return sentencesWithBrackets;
        }

        private List<string> GetAllSentences()
        {
            List<string> sentences = new List<string>();
            int start = 0;

            for (int i = 0; i < Text.Length; i++)
            {
                char character = Text[i];

                if (character == '!' || character == '?' || character == '.')
                {
                    string sentence = Text.Substring(start, i - start + 1).Trim();
                    sentences.Add(sentence);
                    start = i + 1;
                }
            }

            string lastSentence = Text.Substring(start).Trim();
            if (lastSentence != "")
            {
                sentences.Add(lastSentence);
            }

            return sentences;
        }
    }
}
