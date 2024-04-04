using Festivise.Events.Storage.Contracts;
using Festivise.Schedules.Api.Contracts.DTO;
using Festivise.Schedules.Api.Extensions;
using Festivise.Schedules.Storage;
using Festivise.Schedules.Storage.Contracts;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Festivise.Schedules.Api.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IHttpClientFactory httpClientFactory, IScheduleRepository scheduleRepository)
        {
            _httpClientFactory = httpClientFactory;
            _scheduleRepository = scheduleRepository;
        }

        public async Task<ScheduleResponseDto> CreateScheduleAsync(ScheduleRequestDto request)
        {
            using HttpClient client = _httpClientFactory.CreateClient();
            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            options.Converters.Add(new JsonStringEnumConverter());

            var eventresponse = await client.GetFromJsonAsync<EventModel>($"https://localhost:7172/api/events/{request.EventId}", options);

            var model = new ScheduleModel
            {
                EventName = eventresponse.Name,
                EventId = eventresponse.Id,
                Acts = eventresponse.Acts,
                EventVenue = eventresponse.Venue.ToString(),
                UserId = request.UserId,
            };

            var created = await _scheduleRepository.CreateScheduleAsync(model);
            var response = created.ToScheduleResponseDto();
            return response;


        }

        public async Task<ScheduleResponseDto> GetScheduleAsync(string id)
        {
            var schedule = await _scheduleRepository.GetScheduleAsync(id);
            return schedule.ToScheduleResponseDto();
            
        }
    }
}