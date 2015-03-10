 using System;
 using System.Collections.Generic;
 using System.IO;
 using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class ThreeLetterWordList : IWordList
    {
        private const string WordListFile = "ThreeLetterWords.txt";
        private HashSet<string> _words;

        public static IWordList Create()
        {
            var wordList = new ThreeLetterWordList();
            wordList.Initialize();

            return wordList;
        }

        private ThreeLetterWordList()
        {
        }

        private void Initialize()
        {
            var words = File.ReadAllLines(WordListFile);
            _words = new HashSet<string>(words, StringComparer.OrdinalIgnoreCase);
        }

        public bool Contains(string word)
        {
            return _words.Contains(word);
        }
    }
}