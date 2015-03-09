namespace InterviewQuestions
{
    public class CatDogGame : ICatDogGame
    {
        public static ICatDogGame Create()
        {
            return new CatDogGame();
        }

        public bool HasValidTransformation(string @from, string to, IWordList dictionary)
        {
            return true;
        }
    }
}