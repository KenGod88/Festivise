using Festivise.Events.Api.Contracts.DTO;
using Festivise.Events.Api.Extensions;
using Festivise.Events.Storage;

namespace Festivise.Events.Api.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IPosterRepository _posterRepository;
        
        

        public EventService(IEventRepository eventRepository, IPosterRepository posterRepository)
        {
            _eventRepository = eventRepository;
            _posterRepository = posterRepository;
            
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

            var poster = await _posterRepository.GenerateEventPosterAsync(created);

            created.PosterImgUrl = poster;

            return created;
        }

    }
}
