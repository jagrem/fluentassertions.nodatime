using System;
using FluentAssertions.NodaTime;
using NodaTime;

namespace FluentAssertions
{
    public static class LocalTimeAssertionsExtensions
    {
        public static LocalTimeAssertions Should(this LocalTime? value)
        {
            if(value == null) throw new ArgumentNullException(nameof(value));
            return new LocalTimeAssertions(value);
        }
    }
}