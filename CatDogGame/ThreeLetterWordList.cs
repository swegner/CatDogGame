 namespace InterviewQuestions
{
    public class ThreeLetterWordList : IWordList
    {
        public static IWordList Create()
        {
            return new ThreeLetterWordList();
        }

        public bool Contains(string word)
        {
            throw new System.NotImplementedException();
        }
    }
}