using System;
using System.Linq;

namespace InterviewQuestions.Tests
{
    public static class EnumerableExtensions
    {
        public static TimeSpan Average(this IOrderedEnumerable<TimeSpan> timespans)
        {
            var averageTicks = timespans.Average(timing => timing.Ticks);
            return TimeSpan.FromTicks((long)averageTicks);
        }
    }
}