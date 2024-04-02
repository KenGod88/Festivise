using Festivise.Events.Domain.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Festivise.Schedules.Domain.Models
{
    public class ScheduleModel : IDocument
    {
        public string Id { get; set; }
        public string UserId { get; set; }

        public string EventName { get; set; }
        public List<Act> Acts { get; set; }
        public DateTime CreatedAt { get; set; }

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(20);
                page.PageColor(Colors.White);

                page.Header()
                .Text($"Schedule for Event: {EventName}")
                .SemiBold().FontSize(20);

                page.Content()
                .Column(column =>
                {
                    foreach (var act in Acts)
                    {
                        column.Spacing(10);
                        column.Item().Text(act.Name).FontSize(16).SemiBold();
                        column.Item().Text($"Start Time: {act.StartTime}").FontSize(12);
                        column.Item().Text($"End Time: {act.EndTime}").FontSize(12);
                        column.Item().Text($"Duration: {act.Duration}").FontSize(12);
                    }
                }

                    );
            });
        }
    }
}