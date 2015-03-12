using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewQuestions
{
    public class PrecomputedImplementation : BaseImplementation, ICatDogGame
    {
        private readonly Dictionary<string, int> _wordSetMap;

        private PrecomputedImplementation(IWordList wordList)
        {
            _wordSetMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            int wordSetIndex = 0;
            Queue<string> queue = new Queue<string>();
            while (wordList.Any())
            {
                wordSetIndex++;

                string firstWord = wordList.First();
                wordList = wordList.Without(firstWord);
                _wordSetMap[firstWord] = wordSetIndex;

                EnqueueNeighbors(firstWord, queue, ref wordList);
                
                while (queue.Any())
                {
                    string word = queue.Dequeue();
                    _wordSetMap[word] = wordSetIndex;
                    EnqueueNeighbors(word, queue, ref wordList);
                }
            }
        }

        private void EnqueueNeighbors(string word, Queue<string> queue, ref IWordList wordList)
        {
            foreach (var neighbor in EnumerateNeighbors(word, wordList))
            {
                wordList = wordList.Without(neighbor);
                queue.Enqueue(neighbor);
            }
        }

        public static ICatDogGame Create(IWordList wordList)
        {
            return new PrecomputedImplementation(wordList);
        }

        public bool HasValidTransformation(string from, string to)
        {
            int fromSetId;
            int toSetId;

            return _wordSetMap.TryGetValue(from, out fromSetId)
                   && _wordSetMap.TryGetValue(to, out toSetId)
                   && fromSetId == toSetId;
        }
    }
}