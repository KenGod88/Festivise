

using Festivise.Schedules.Api.Services;
using System.Text.Json.Serialization;
using Festivise.Schedules.Storage;
using System.Text.Json;
using NSwag;

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

            builder.Services.AddOpenApiDocument(options => {
                options.PostProcess = document =>
                {
                    document.Info = new OpenApiInfo
                    {
                        Title = "Festivise/Schedules Api",
                        Description = "Festivise Api for event and schedule creation",
                        Contact = new OpenApiContact
                        {
                            Name = "Ken Godfroid",
                            Email = "Ken.godfroid@hogent.be"
                        }
                    };
                };
            });



            var app = builder.Build();
            app.MapControllers();

            app.UseOpenApi();
            app.UseSwaggerUi();



            app.Run();
        }
    }
}
