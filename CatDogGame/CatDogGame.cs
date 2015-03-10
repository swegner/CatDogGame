﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace InterviewQuestions
{
    public class CatDogGame : ICatDogGame
    {
        public static ICatDogGame Create()
        {
            return new CatDogGame();
        }

        public bool HasValidTransformation(string from, string to, IWordList dictionary)
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

                foreach (string neighbor in EnumerateNeighbors(currentFrom, dictionary))
                {
                    if (!triedWords.Contains(neighbor))
                    {
                        Trace.WriteLine(string.Format("{0} -> {1}", currentFrom, neighbor));

                        queue.Enqueue(neighbor);
                        triedWords.Add(neighbor);
                    }
                }
            }

            return false;
        }

        private IEnumerable<string> EnumerateNeighbors(string word, IWordList dictionary)
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