using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterviewQuestions.Tests
{
    [TestClass]
    public class AcceptanceTests
    {
        [TestMethod]
        public void SimplePositiveTest()
        {
            "CAT".ShouldHaveTransformationTo("DOG");
        }

        [TestMethod]
        public void SimpleNegativeTest()
        {
            "CAT".ShouldNotHaveTransformationTo("UFO");
        }
    }
}