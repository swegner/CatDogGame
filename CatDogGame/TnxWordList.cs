using System;
using System.Collections.Immutable;
using System.Linq;
using TNX.NamesAndPassword;

namespace InterviewQuestions
{
    public class TnxWordList : WordList
    {
        public TnxWordList()
            : this(GetWordsFromDictionary())
        {
        }

        private TnxWordList(ImmutableHashSet<string> words) 
            : base(words)
        {
        }


        private static ImmutableHashSet<string> GetWordsFromDictionary()
        {
            var words = WorldDictionary.GetWordsForCulture("en");
            var wordsArr = words.ToArray();
            return ImmutableHashSet.Create(StringComparer.OrdinalIgnoreCase, wordsArr);
        }

        public static IWordList Create()
        {
            return new TnxWordList();
        }

        protected override IWordList Create(ImmutableHashSet<string> words)
        {
            return new TnxWordList(words);
        }
    }
}