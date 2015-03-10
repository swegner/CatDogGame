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
        private static readonly string[] SampleWords =
        {
            "aim",
            "ate",
            "buy",
            "did",
            "fee",
            "hes",
            "ilk",
            "key",
            "mad",
            "mud",
            "nut",
            "own",
            "pis",
            "rev",
            "sin",
            "toe",
            "way",
            "yen",
        };

        private static InputPair[] _inputPairs;
        private static IWordList _wordDictionary;
        private static TestContext _testContext;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _testContext = context;
            GenerateInputPairs();
            _wordDictionary = ThreeLetterWordList.Create();
        }

        private static void GenerateInputPairs()
        {
            const int numIterations = 1000;
            _inputPairs = new InputPair[numIterations];

            var random = new Random();
            int numSampleWords = SampleWords.Length;
                
            for (int i = 0; i < numIterations; i++)
            {
                int fromIdx = random.Next(numSampleWords);
                int toIdx = random.Next(numSampleWords);

                _inputPairs[i] = InputPair.Create(SampleWords[fromIdx], SampleWords[toIdx]);
            }
        }

        [TestMethod]
        public void TestNaiveImplementation()
        {
            var catDogGame = NaiveImplementation.Create(_wordDictionary);
            RunPerfTest(catDogGame);
        }

        private void RunPerfTest(ICatDogGame catDogGame)
        {
            List<TimeSpan> timings = new List<TimeSpan>();
            Stopwatch stopwatch = Stopwatch.StartNew();
            var numIterations = _inputPairs.Length;

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
            _testContext.WriteLine("Median: {0}", orderedTimings.ElementAt((numIterations / 2)));
            _testContext.WriteLine("75th Percentile: {0}", orderedTimings.ElementAt(((int)(numIterations * 0.75))));
            _testContext.WriteLine("90th Percentile: {0}", orderedTimings.ElementAt(((int)(numIterations * 0.9))));
            _testContext.WriteLine("Max: {0}", orderedTimings.Last());

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