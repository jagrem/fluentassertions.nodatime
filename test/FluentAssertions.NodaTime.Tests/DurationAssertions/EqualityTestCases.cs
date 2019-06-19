using System.Collections.Generic;
using NUnit.Framework;

namespace FluentAssertions.NodaTime.Tests.DurationAssertions
{
    public static class EqualityTestCases
    {
        public static IEnumerable<TestCaseData> GetShortAndLongDurations()
        {
            yield return new TestCaseData(10, 11);
            yield return new TestCaseData(-10, 11);
            yield return new TestCaseData(10, -11);
            yield return new TestCaseData(-10, -11);
        }

        public static IEnumerable<TestCaseData> GetEqualDurations()
        {
            yield return new TestCaseData(10, 10);
            yield return new TestCaseData(-10, 10);
            yield return new TestCaseData(10, -10);
            yield return new TestCaseData(-10, -10);
        }

        public static IEnumerable<TestCaseData> GetLongAndShortDurations()
        {
            yield return new TestCaseData(11, 10);
            yield return new TestCaseData(-11, 10);
            yield return new TestCaseData(11, -10);
            yield return new TestCaseData(-11, -10);
        }


    }
}
