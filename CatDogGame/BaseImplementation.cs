using System.Collections.Generic;

namespace InterviewQuestions
{
    public class BaseImplementation
    {
        protected IEnumerable<string> EnumerateNeighbors(string word, IWordList dictionary)
        {
            for (int i = 0; i < word.Length; i++)
            {
                for (char newLetter = 'a'; newLetter <= 'z'; newLetter++)
                {
                    if (word[i] != newLetter)
                    {
                        string newWord = word.Substring(0, i) + newLetter + word.Substring(i + 1, word.Length - i - 1);
                        if (dictionary.Contains(newWord))
                        {
                            yield return newWord;
                        }
                    }
                }
            }
        }
    }
}