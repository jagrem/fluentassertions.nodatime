using System;
using FluentAssertions.NodaTime;
using NodaTime;

namespace FluentAssertions
{
    public static class InstantAssertionsExtensions
    {
        public static InstantAssertions Should(this Instant? value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            return new InstantAssertions(value);
        }

        public static InstantAssertions Should(this Instant value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            return new InstantAssertions(value);
        }
    }
}
