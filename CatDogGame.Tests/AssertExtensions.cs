using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterviewQuestions.Tests
{
    public static class AssertExtensions
    {
        public static void ShouldHaveTransformationTo(this string from, string to)
        {
            var hasTransformation = CatDogTestHarness.TestTransformation(@from, to);
            Assert.IsTrue(hasTransformation);
        }

        public static void ShouldNotHaveTransformationTo(this string from, string to)
        {
            var hasTransformation = CatDogTestHarness.TestTransformation(@from, to);
            Assert.IsFalse(hasTransformation);
        }

        public static void ShouldContain(this IWordList wordList, string word)
        {
            bool contains = wordList.Contains(word);
            Assert.IsTrue(contains);
        }

        public static void ShouldNotContain(this IWordList wordList, string word)
        {
            bool contains = wordList.Contains(word);
            Assert.IsFalse(contains);
        }
    }
}