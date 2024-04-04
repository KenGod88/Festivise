using Festivise.Events.Storage.Contracts;

namespace Festivise.Events.Storage
{
    public interface IEventRepository
    {
        Task<EventModel> GetEventAsync(Guid id);
        Task<EventModel> CreateEventAsync(EventModel eventToAdd);
    }
}
