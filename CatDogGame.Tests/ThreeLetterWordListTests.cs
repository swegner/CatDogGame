using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterviewQuestions.Tests
{
    [TestClass, DeploymentItem("ThreeLetterWords.txt")]
    public class ThreeLetterWordListTests
    {
        private IWordList _wordList;

        [TestInitialize]
        public void TestInitialize()
        {
            _wordList = ThreeLetterWordList.Create();
        }

        [TestMethod]
        public void SimplePositiveTest()
        {
            _wordList.ShouldContain("CAT");
        }

        [TestMethod]
        public void SimpleNegativeTest()
        {
            _wordList.ShouldNotContain("QXJ");
        }
    }
}