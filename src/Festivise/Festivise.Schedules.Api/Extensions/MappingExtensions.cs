using Festivise.Schedules.Api.Contracts.DTO;
using Festivise.Schedules.Storage.Contracts;

namespace Festivise.Schedules.Api.Extensions
{
    public static class MappingExtensions
    {
        public static ScheduleResponseDto ToScheduleResponseDto(this ScheduleModel schedule)
        {
            return new ScheduleResponseDto
            {
                Id = schedule.Id,
                EventName = schedule.EventName,
                EventId = schedule.EventId,
                Acts = schedule.Acts,
                EventVenue = schedule.EventVenue,
                UserId = schedule.UserId
            };
        }

        public static ScheduleModel ToSchedule(this ScheduleRequestDto request)
        {
            return new ScheduleModel
            {
                EventId = request.EventId,

                UserId = request.UserId
            };
        }
    }
}