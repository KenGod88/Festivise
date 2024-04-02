using Festivise.Events.Api.Contracts.DTO;
using Festivise.Events.Api.Extensions;
using Festivise.Events.Storage;

namespace Festivise.Events.Api.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        
        

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
            
        }

        public async Task<EventResponseDTO> GetEventAsync(Guid id)
        {
            var eventEntity = await _eventRepository.GetEventAsync(id);

            if (eventEntity == null)
            {
                return null;
            }

            var eventDTO = eventEntity.MapToEventResponseDTO();

            return eventDTO ;
        }

        public async Task<EventResponseDTO> CreateEventAsync(EventRequestDTO eventRequestDTO)
        {
            var eventEntity = eventRequestDTO.MapToEvent();

            var createdEvent = await _eventRepository.CreateEventAsync(eventEntity);

            EventResponseDTO created = createdEvent.MapToEventResponseDTO();

            return created;
        }

    }
}
