using System.Collections.Generic;
using System.Linq;

namespace InterviewQuestions
{
    public class NaiveImplementation : BaseImplementation, ICatDogGame
    {
        private readonly IWordList _dictionary;

        private NaiveImplementation(IWordList dictionary)
        {
            _dictionary = dictionary;
        }

        public static ICatDogGame Create(IWordList dictionary)
        {
            return new NaiveImplementation(dictionary);
        }

        public string Name
        {
            get { return "Naive"; }
        }

        public bool HasValidTransformation(string from, string to)
        {
            from = from.ToLowerInvariant();
            to = to.ToLowerInvariant();

            HashSet<string> triedWords = new HashSet<string>();
            Queue<string> queue = new Queue<string>();

            queue.Enqueue(from);
            triedWords.Add(from);

            while (queue.Any())
            {
                string currentFrom = queue.Dequeue();

                if (currentFrom == to)
                {
                    return true;
                }

                foreach (string neighbor in EnumerateNeighbors(currentFrom, _dictionary))
                {
                    if (!triedWords.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        triedWords.Add(neighbor);
                    }
                }
            }

            return false;
        }
    }
}