

using Festivise.Schedules.Api.Services;
using System.Text.Json.Serialization;
using Festivise.Schedules.Storage;
using System.Text.Json;

namespace Festivise.Schedules.Api

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            }).AddMvcOptions(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true 
            };

            builder.Services.Configure<ScheduleRepositoryOptions>(
                    builder.Configuration.GetSection(
                        key: nameof(ScheduleRepositoryOptions)));

            builder.Services.AddHttpClient();

            builder.Services.AddScoped<IScheduleService, ScheduleService>();
            builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();



            var app = builder.Build();
            app.MapControllers();

            

            app.Run();
        }
    }
}
