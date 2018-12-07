using FluentAssertions.Primitives;
using NodaTime;

namespace FluentAssertions.NodaTime
{
    public class PeriodAssertions : ReferenceTypeAssertions<Period, PeriodAssertions>
    {
        protected override string Identifier => "Period";
        public PeriodAssertions(Period subject)
        {
            Subject = subject;
        }
    }
}