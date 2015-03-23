using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TNX.NamesAndPassword;

namespace InterviewQuestions
{
    public class WordList : IWordList
    {
        private readonly ImmutableHashSet<string> _words;

        public WordList()
            : this(GetWordsFromDictionary())
        {
        }

        private WordList(ImmutableHashSet<string> words)
        {
            _words = words;
        }

        public static IWordList Create()
        {
            return new WordList();
        }

        public IWordList Without(string word)
        {
            ImmutableHashSet<string> newWordList = _words.Remove(word);
            return new WordList(newWordList);
        }

        public bool Contains(string word)
        {
            return _words.Contains(word);
        }

        public IEnumerator GetEnumerator()
        {
            return _words.GetEnumerator();
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return ((ICollection<string>) _words).GetEnumerator();
        }

        private static ImmutableHashSet<string> GetWordsFromDictionary()
        {
            var words = WorldDictionary.GetWordsForCulture("en");
            var wordsArr = words.ToArray();
            return ImmutableHashSet.Create(StringComparer.OrdinalIgnoreCase, wordsArr);
        }

    }
}