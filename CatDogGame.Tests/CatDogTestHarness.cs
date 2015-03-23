using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterviewQuestions.Tests
{
    public class CatDogTestHarness
    {
        public static bool TestTransformation(string from, string to)
        {
            var wordList = WordList.Create();
            var naiveImplementation = NaiveImplementation.Create(wordList);
            var precomputedImplementation = PrecomputedImplementation.Create(wordList);

            var naiveResult = naiveImplementation.HasValidTransformation(from, to);
            var precomputedResult = precomputedImplementation.HasValidTransformation(from, to);

            Assert.AreEqual(naiveResult, precomputedResult);
            return naiveResult;
        }
    }
}