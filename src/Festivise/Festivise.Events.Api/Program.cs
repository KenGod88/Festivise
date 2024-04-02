using Festivise.Events.Api.Services;
using Festivise.Events.Storage;
using Festivise.Events.Storage.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Festivise.Events.Api

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

            builder.Services.AddScoped<IEventRepository, EventRepository>();
            builder.Services.AddScoped<IEventService, EventService>();


            builder.Services.AddDbContext<FestiviseContext>(options =>
                options.UseSqlServer(builder.Configuration.GetSection("EventRepositoryOptions:ConnectionString").Value));



            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }
    }
}