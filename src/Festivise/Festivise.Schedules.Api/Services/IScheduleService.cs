using Festivise.Schedules.Api.Contracts.DTO;
using Festivise.Schedules.Storage.Contracts;

namespace Festivise.Schedules.Api.Services
{
    public interface IScheduleService
    {
        Task<ScheduleResponseDto> CreateScheduleAsync(ScheduleRequestDto request);
        Task<ScheduleResponseDto> GetScheduleAsync(string id);
    }
}
