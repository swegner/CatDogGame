using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterviewQuestions.Tests
{
    [TestClass]
    public class PerformanceTests
    {
        private static InputPair[] _inputPairs;
        private static IWordList _wordDictionary;
        private static TestContext _testContext;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _testContext = context;
            _wordDictionary = WordList.Create();

            GenerateInputPairs();
        }

        private static void GenerateInputPairs()
        {
            var iterationsPerLength = new[]
            {
                100, // 2
                500, // 3
                500, // 4
                1000, // 5
                500, // 6
                100, // 7
                100, // 8
            };

            var random = new Random();
            var wordsByLength = _wordDictionary
                .GroupBy(word => word.Length)
                .ToDictionary(g => g.Key, g => g.ToArray());

            List<InputPair> inputPairs = new List<InputPair>();
            for (int i = 0; i < iterationsPerLength.Length; i++)
            {
                int wordLength = i + 2;
                var wordsOfLength = wordsByLength[wordLength];
                int numWordsOfLength = wordsOfLength.Length;

                var from = wordsOfLength[random.Next(numWordsOfLength)];
                var to = wordsOfLength[random.Next(numWordsOfLength)];

                inputPairs.Add(InputPair.Create(from, to));
            }

            _inputPairs = inputPairs.ToArray();
        }

        [TestMethod]
        public void ComparePerf()
        {
            var naiveImplementation = NaiveImplementation.Create(_wordDictionary);
            var precomputed = PrecomputedImplementation.Create(_wordDictionary);

            RunPerfTest(naiveImplementation, precomputed);
        }

        private void RunPerfTest(params ICatDogGame[] catDogGames)
        {
            List<TimeSpan> timings = new List<TimeSpan>();
            Stopwatch stopwatch = Stopwatch.StartNew();
            var numIterations = _inputPairs.Length;

            foreach (var catDogGame in catDogGames)
            {
                _testContext.WriteLine("Testing implementation: {0}", catDogGame.Name);

                for (int i = 0; i < numIterations; i++)
                {
                    var inputPair = _inputPairs[i];

                    stopwatch.Restart();
                    catDogGame.HasValidTransformation(inputPair.From, inputPair.To);
                    TimeSpan timing = stopwatch.Elapsed;

                    timings.Add(timing);
                }

                var orderedTimings = timings.OrderBy(timing => timing);

                _testContext.WriteLine("Average: {0}", orderedTimings.Average());
                _testContext.WriteLine("Min: {0}", orderedTimings.First());
                _testContext.WriteLine("Median: {0}", orderedTimings.ElementAt((numIterations/2)));
                _testContext.WriteLine("75th Percentile: {0}", orderedTimings.ElementAt(((int) (numIterations*0.75))));
                _testContext.WriteLine("90th Percentile: {0}", orderedTimings.ElementAt(((int) (numIterations*0.9))));
                _testContext.WriteLine("Max: {0}", orderedTimings.Last());
                _testContext.WriteLine("");
            }
        }

        private class InputPair
        {
            public static InputPair Create(string from, string to)
            {
                return new InputPair
                {
                    From = from,
                    To = to,
                };
            }

            private InputPair()
            {
            }

            public string From { get; private set; }

            public string To { get; private set; }
        }
    }
}