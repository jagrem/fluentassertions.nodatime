using FluentAssertions.Primitives;
using NodaTime;

namespace FluentAssertions.NodaTime
{
    public class InstantAssertions
    {
        public Instant? Subject { get; }
        public InstantAssertions(Instant? subject)
        {
            Subject = subject;
        }
    }
}