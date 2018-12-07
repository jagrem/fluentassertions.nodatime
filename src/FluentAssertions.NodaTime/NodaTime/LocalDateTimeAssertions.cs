using FluentAssertions.Primitives;
using NodaTime;

namespace FluentAssertions.NodaTime
{
    public class LocalDateTimeAssertions
    {
        public LocalDateTime? Subject { get; }
        public LocalDateTimeAssertions(LocalDateTime? subject) => Subject = subject;
    }
}