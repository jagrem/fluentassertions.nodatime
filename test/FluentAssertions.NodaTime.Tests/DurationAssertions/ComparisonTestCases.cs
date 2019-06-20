using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace FluentAssertions.NodaTime.Tests.DurationAssertions
{
    public static class ComparisonTestCases
    {
        const int n = 10;

        static (int Expected, int Actual)[] allTestCases = new[] {
            (n, n + 1),
            (-n, n),
            (-n, -n + 1),
            (n, n),
            (0, 0),
            (n + 1, n),
            (n, -n),
            (-n + 1, -n)
        };

        static TestCaseData ToTestCase((int Expected, int Actual) pair) => new TestCaseData(pair.Expected, pair.Actual);

        public static IEnumerable<TestCaseData> LessThan() =>
            allTestCases
                .Where(pair => pair.Expected < pair.Actual)
                .Select(ToTestCase);

        public static IEnumerable<TestCaseData> Equal() =>
            allTestCases
                .Where(pair => pair.Expected == pair.Actual)
                .Select(ToTestCase);

        public static IEnumerable<TestCaseData> GreaterThan() =>
            allTestCases
                .Where(pair => pair.Expected > pair.Actual)
                .Select(ToTestCase);

        public static IEnumerable<TestCaseData> NotEqual() =>
            allTestCases
                .Where(pair => pair.Expected != pair.Actual)
                .Select(ToTestCase);
    }
}
