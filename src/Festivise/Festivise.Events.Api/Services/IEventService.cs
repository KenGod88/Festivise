using Festivise.Events.Api.Contracts.DTO;


namespace Festivise.Events.Api.Services
{
    public interface IEventService
    {
        Task<EventResponseDTO> GetEventAsync(Guid id);
        Task<EventResponseDTO> CreateEventAsync(EventRequestDTO eventRequestDTO);
        
    }
}
