using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterviewQuestions.Tests
{
    [TestClass]
    public class TnxWordListTests
    {
        private IWordList _wordList;

        [TestInitialize]
        public void TestInitialize()
        {
            _wordList = TnxWordList.Create();
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