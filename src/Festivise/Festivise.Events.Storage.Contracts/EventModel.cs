namespace Festivise.Events.Storage.Contracts
{
    public class EventModel
    {
        public Guid Id { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }


        public DateTime StartTime { get; set; }


        public DateTime EndTime { get; set; }


        public VenueEnum Venue { get; set; }


        public List<ActModel>? Acts { get; set; }
    }
}
