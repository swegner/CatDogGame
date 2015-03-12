 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Collections.Immutable;
 using System.IO;

namespace InterviewQuestions
{
    public class ThreeLetterWordList : IWordList
    {
        private const string WordListFile = "ThreeLetterWords.txt";
        
        private readonly ImmutableHashSet<string> _words;

        public static IWordList Create()
        {
            var wordList = new ThreeLetterWordList();
            return wordList;
        }

        private ThreeLetterWordList()
            : this(ReadWordListFromFile(WordListFile))
        {
        }

        private ThreeLetterWordList(ImmutableHashSet<string> words)
        {
            _words = words;
        }

        public IWordList Without(string word)
        {
            ImmutableHashSet<string> newWordList = _words.Remove(word);
            return new ThreeLetterWordList(newWordList);
        }

        private static ImmutableHashSet<string> ReadWordListFromFile(string wordListFile)
        {
            var words = File.ReadAllLines(wordListFile);
            return ImmutableHashSet.Create(StringComparer.OrdinalIgnoreCase, words);
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return ((ICollection<string>) _words).GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return _words.GetEnumerator();
        }

        public bool Contains(string word)
        {
            return _words.Contains(word);
        }
    }
}