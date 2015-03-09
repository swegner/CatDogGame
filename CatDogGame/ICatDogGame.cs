namespace CatDogGame
{
    public interface ICatDogGame
    {
        bool HasValidTransformation(string to, string from, IWordList dictionary);
    }
}
