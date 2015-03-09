using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterviewQuestions.Tests
{
    public static class AssertExtensions
    {
        public static void ShouldHaveTransformationTo(this string from, string to)
        {
            var hasTransformation = TestTransformation(@from, to);
            Assert.IsTrue(hasTransformation);
        }

        public static void ShouldNotHaveTransformationTo(this string from, string to)
        {
            var hasTransformation = TestTransformation(@from, to);
            Assert.IsFalse(hasTransformation);
        }
        
        private static bool TestTransformation(string @from, string to)
        {
            bool hasTransformation = CatDogTestHarness.TestTransformation(@from, to);
            return hasTransformation;
        }
    }
}