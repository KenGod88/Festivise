using Festivise.Events.Api.Contracts.DTO;
using Festivise.Events.Domain.Models;

namespace Festivise.Events.Api.Extensions
{
    public static class MappingExtensions
    {
        public static Event MapToEvent(this EventRequestDTO eventRequestDTO)
        {
            return new Event
            {
                Id = eventRequestDTO.Id,
                Name = eventRequestDTO.Name,
                Description = eventRequestDTO.Description,
                StartTime = eventRequestDTO.StartTime,
                EndTime = eventRequestDTO.EndTime,
                Venue = eventRequestDTO.Venue,
                Acts = eventRequestDTO.Acts.MapToActs() 
            };
        }

        public static Act MapToAct(this ActRequestDTO actRequestDTO)
        {
            return new Act
            {
                Id = actRequestDTO.Id,
                Name = actRequestDTO.Name,
                Duration = actRequestDTO.Duration 
            };
        }

        
        public static List<Act> MapToActs(this IEnumerable<ActRequestDTO> actRequestDTOs)
        {
            if (actRequestDTOs == null) return new List<Act>();
            return actRequestDTOs.Select(dto => dto.MapToAct()).ToList();
        }
    }
}
