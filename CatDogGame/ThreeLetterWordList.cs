 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Collections.Immutable;
 using System.IO;

namespace InterviewQuestions
{
    public abstract class WordList : IWordList
    {
        private readonly ImmutableHashSet<string> _words;

        protected WordList(ImmutableHashSet<string> words)
        {
            _words = words;
        }

        public IWordList Without(string word)
        {
            ImmutableHashSet<string> newWordList = _words.Remove(word);
            return Create(newWordList);
        }

        protected abstract IWordList Create(ImmutableHashSet<string> words);

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

    public class ThreeLetterWordList : WordList
    {
        private const string WordListFile = "ThreeLetterWords.txt";

        public static IWordList Create()
        {
            var wordList = new ThreeLetterWordList();
            return wordList;
        }

        protected override IWordList Create(ImmutableHashSet<string> words)
        {
            return new ThreeLetterWordList(words);
        }

        private ThreeLetterWordList()
            : this(ReadWordListFromFile(WordListFile))
        {
        }

        private ThreeLetterWordList(ImmutableHashSet<string> words)
            : base(words)
        {
        }

        private static ImmutableHashSet<string> ReadWordListFromFile(string wordListFile)
        {
            var words = File.ReadAllLines(wordListFile);
            return ImmutableHashSet.Create(StringComparer.OrdinalIgnoreCase, words);
        }
    }
}