using System;
using FluentAssertions.NodaTime;
using NodaTime;

namespace FluentAssertions
{
    public static class LocalDateTimeAssertionsExtensions
    {
        public static LocalDateTimeAssertions Should(this LocalDateTime? value)
        {
            if(value == null) throw new ArgumentNullException(nameof(value));
            return new LocalDateTimeAssertions(value);
        }
    }
}