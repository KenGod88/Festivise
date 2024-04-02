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

        public static EventResponseDTO MapToEventResponseDTO(this Event eventModel)
               {
            return new EventResponseDTO
            {
                Id = eventModel.Id,
                Name = eventModel.Name,
                Description = eventModel.Description,
                StartTime = eventModel.StartTime,
                EndTime = eventModel.EndTime,
                Venue = eventModel.Venue,
                Acts = eventModel.Acts.MapToActResponseDTOs()
            };
        }

        public static ActResponseDTO MapToActResponseDTO(this Act actModel)
        {
            return new ActResponseDTO
            {
                Id = actModel.Id,
                Name = actModel.Name,
                Duration = actModel.Duration
            };
            
        }

        public static List<ActResponseDTO> MapToActResponseDTOs(this IEnumerable<Act> actModels)
        {
            if (actModels == null) return new List<ActResponseDTO>();
            return actModels.Select(model => model.MapToActResponseDTO()).ToList();
        }
    }
}
