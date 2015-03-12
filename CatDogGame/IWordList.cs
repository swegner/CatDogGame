using System.Collections;
using System.Collections.Generic;

namespace InterviewQuestions
{
    public interface IWordList : IEnumerable<string>
    {
        bool Contains(string word);

        IWordList Without(string word);
    }
}