using System;
using FluentAssertions.NodaTime;
using NodaTime;

namespace FluentAssertions
{
    public static class LocalDateAssertionsExtensions
    {
        public static LocalDateAssertions Should(this LocalDate? value)
        {
            if(value == null) throw new ArgumentNullException(nameof(value));
            return new LocalDateAssertions(value);
        }
    }
}