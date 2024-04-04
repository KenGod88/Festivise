using Festivise.Events.Api.Contracts.DTO;
using Festivise.Events.Storage.Contracts;

namespace Festivise.Events.Api.Extensions
{
    public static class MappingExtensions
    {
        public static EventModel MapToEvent(this EventRequestDTO eventRequestDTO)
        {
            return new EventModel
            {
                Id = eventRequestDTO.Id,
                Name = eventRequestDTO.Name,
                Description = eventRequestDTO.Description,
                StartTime = eventRequestDTO.StartTime,
                EndTime = eventRequestDTO.EndTime,
                Venue = eventRequestDTO.Venue,
                Acts = eventRequestDTO.Acts
            };
        }

        public static EventResponseDTO MapToEventResponseDTO(this EventModel eventModel)
        {
            return new EventResponseDTO
            {
                Id = eventModel.Id,
                Name = eventModel.Name,
                Description = eventModel.Description,
                StartTime = eventModel.StartTime,
                EndTime = eventModel.EndTime,
                Venue = eventModel.Venue,
                Acts = eventModel.Acts
            };
        }
    }
}