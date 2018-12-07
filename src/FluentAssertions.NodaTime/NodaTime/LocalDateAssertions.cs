using FluentAssertions;
using FluentAssertions.Primitives;
using NodaTime;

namespace FluentAssertions.NodaTime
{
    public class LocalDateAssertions
    {
        public LocalDate? Subject { get; }
        public LocalDateAssertions(LocalDate? subject) => Subject = subject;
    }
}