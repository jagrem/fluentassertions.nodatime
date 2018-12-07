using FluentAssertions.Primitives;
using NodaTime;

namespace FluentAssertions.NodaTime
{
    public class LocalTimeAssertions
    {
        public LocalTime? Subject { get; }
        public LocalTimeAssertions(LocalTime? subject) => Subject = subject;
    }
}