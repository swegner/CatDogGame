namespace InterviewQuestions
{
    public interface ICatDogGame
    {
        string Name { get; }
        bool HasValidTransformation(string from, string to);
    }
}
