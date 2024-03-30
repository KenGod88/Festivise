using Festivise.Events.Api.Contracts.DTO;


namespace Festivise.Events.Api.Services
{
    public interface IEventService
    {
        Task<EventResponseDTO> GetEvent(Guid id);
        Task<EventResponseDTO> CreateEvent(EventRequestDTO eventRequestDTO);
        
    }
}
