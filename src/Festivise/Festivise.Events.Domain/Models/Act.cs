namespace Festivise.Events.Domain.Models
{
    public class Act
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }

        public Guid EventId { get; set; }
        public Event Event { get; set; }
    }
}