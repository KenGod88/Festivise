using QuestPDF.Infrastructure;

namespace Festivise.Schedules.Api

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            QuestPDF.Settings.License = LicenseType.Community;

            var app = builder.Build();

            

            app.Run();
        }
    }
}
