using System;
using FluentAssertions.NodaTime;
using NodaTime;

namespace FluentAssertions
{
    public static class DurationAssertionsExtensions
    {
        public static DurationAssertions Should(this Duration? value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            return new DurationAssertions(value);
        }

        public static DurationAssertions Should(this Duration value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            return new DurationAssertions(value);
        }
    }
}
