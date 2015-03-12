namespace InterviewQuestions.Tests
{
    public class CatDogTestHarness
    {
        public static bool TestTransformation(string from, string to)
        {
            var wordList = ThreeLetterWordList.Create();
            var catDogGame = PrecomputedImplementation.Create(wordList);
            
            return catDogGame.HasValidTransformation(from, to);
        }
    }
}