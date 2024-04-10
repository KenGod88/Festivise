using Festivise.Events.Api.Services;
using Festivise.Events.Storage;
using Festivise.Events.Storage.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using NSwag;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace Festivise.Events.Api

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddControllers()
                .AddJsonOptions(opt =>
                {
                    
                    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    
                })
                .AddMvcOptions(options =>
                {
                    
                    options.SuppressAsyncSuffixInActionNames = false;
                });

            builder.Services.AddOpenApiDocument(options => {
                options.PostProcess = document =>
                {
                    document.Info = new OpenApiInfo
                    {
                        Title = "Festivise/Events Api",
                        Description = "Festivise Api for event and schedule creation",
                        Contact = new OpenApiContact
                        {
                            Name = "Ken Godfroid",
                            Email = "Ken.godfroid@hogent.be"
                        }
                    };
                };
            });

            builder.Services.AddRateLimiter(l => l.AddFixedWindowLimiter(policyName: "festiviseEventFixed", options =>
            {
                options.PermitLimit = 3;
                options.Window = TimeSpan.FromSeconds(10);
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                options.QueueLimit = 0;
            }));

            builder.Services.AddHttpClient();


            builder.Services.AddScoped<IEventRepository, EventRepository>();
            builder.Services.AddScoped<IEventService, EventService>();
            builder.Services.AddScoped<IPosterRepository, PosterRepository>();

            builder.Services.Configure<PosterRepositoryOptions>(
                    builder.Configuration.GetSection(
                        key: nameof(PosterRepositoryOptions)));


            builder.Services.AddDbContext<FestiviseContext>(options =>
                options.UseSqlServer(builder.Configuration.GetSection("EventRepositoryOptions:ConnectionString").Value));

            


            var app = builder.Build();

            app.MapControllers();
            app.UseOpenApi();
            app.UseSwaggerUi();
            app.UseRateLimiter();

            app.Run();
        }
    }
}