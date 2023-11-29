using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Reflection;

namespace CCRestitution.ReportsRepository
{
    public class ReportDocument : IDocument
    {
        public ReportModel Model { get; }

        public ReportDocument(ReportModel model)
        {
            Model = model;
        }
        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
        public DocumentSettings GetSettings() => DocumentSettings.Default;

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Margin(50);

                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeTable);
                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.CurrentPageNumber();
                        x.Span(" / ");
                        x.TotalPages();
                    });
                });
        }

        void ComposeHeader(IContainer container)
        {
            var titleStyle = TextStyle.Default.FontSize(20).SemiBold().FontColor(Colors.Black);
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text(Model.Title).Style(titleStyle);
                    column.Item().Text(text =>
                    {
                        text.Span("Generated: ").SemiBold();
                        text.Span($"{Model.GeneratedDate:d}");
                    });
                });

                //row.ConstantItem(100).Height(100).Placeholder();

            });
        }

        void ComposeTable(IContainer container)
        { 
            if(Model.ColumnTitles.Count != Model.PropertyNames.Count)
            {
                throw new ArgumentException("Number of column titles must match the number of property names.");
            }

            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    for(int i=0;i<Model.ColumnTitles.Count;i++)
                    {
                        columns.RelativeColumn();
                    }
                });

                table.Header(header =>
                {
                    foreach(string title in Model.ColumnTitles)
                    {
                        header.Cell().Element(CellStyle).Text(title);
                    }

                    static IContainer CellStyle(IContainer container)
                    {
                        return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                    }
                });

                foreach (var item in (IEnumerable<object>)Model.ReportObject)
                {
                    foreach (var propertyName in Model.PropertyNames)
                    {
                        var property = item.GetType().GetProperty(propertyName);
                        if (property != null)
                        {
                            var val = property.GetValue(item);
                            table.Cell().Element(CellStyle).Text(val);
                        }

                        
                    }
                }

                static IContainer CellStyle(IContainer container)
                {
                    return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                }

            });
        }

        private object GetPropertyValue(dynamic obj, string propertyName)
        {
            // Using reflection to get the property value from the dynamic object
            var property = obj.GetType().GetProperty(propertyName);
            if (property != null)
            {
                return property.GetValue(obj);
            }
            return null;
        }
    }

    public class ReportModel
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public DateTime GeneratedDate { get; set; }
        public List<string> ColumnTitles { get; set; }
        public List<string> PropertyNames { get; set; }
        public object ReportObject { get; set; }
    }
}
