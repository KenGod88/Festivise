using Festivise.Events.Api.Contracts.Enums;

namespace Festivise.Events.Domain.Models
{
    public class Event
    {
        
        public Guid Id { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }


        public DateTime StartTime { get; set; }


        public DateTime EndTime { get; set; }


        public VenueEnum Venue { get; set; }


        public List<Act>? Acts { get; set; }
    }
}
