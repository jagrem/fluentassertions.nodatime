using System;
using FluentAssertions.NodaTime;
using NodaTime;

namespace FluentAssertions
{
    public static class PeriodAssertionsExtensions
    {
        public static PeriodAssertions Should(this Period value)
        {
            if(value == null) throw new ArgumentNullException(nameof(value));
            
            return new PeriodAssertions(value);
        }
    }
}