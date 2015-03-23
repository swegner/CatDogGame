using System.Collections;
 using System.Collections.Generic;
 using System.Collections.Immutable;

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
}