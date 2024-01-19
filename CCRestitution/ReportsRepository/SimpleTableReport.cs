using CCRestitution.PdfImplementation.DocumentModels;
using CCRestitution.PdfImplementation.Templates;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace CCRestitution.ReportsRepository
{
    public class SimpleTableReport : BaseReportTemplate
    {
        public ReportDataModel Model { get; }
        public TableReportModel TableData { get; }
        public SimpleTableReport(ReportDataModel model, TableReportModel tableData) : base(model)
        {
            Model = model;
            TableData = tableData;
        }

        public override void ComposeContent(IContainer container)
        {
            container.Column(column =>
            {
                column.Spacing(15);

                if (!String.IsNullOrEmpty(TableData.TableName))
                {
                    column.Item().AlignCenter().Text(TableData.TableName);
                }

                column.Item().Table(table =>
                {
                    IContainer DefaultCellStyle(IContainer container, string backgroundColor)
                    {
                        return container
                            .Border(1)
                            .BorderColor(Colors.Grey.Lighten1)
                            .Background(backgroundColor)
                            .PaddingVertical(5)
                            .PaddingHorizontal(10)
                            .AlignCenter()
                            .AlignMiddle()
                            .DefaultTextStyle(font => font.Size(10));
                    }

                    table.ColumnsDefinition(columns =>
                    {
                        foreach(var col in TableData.ColumnNames)
                        {
                            if(col.Type.ToLower() == "constant")
                            {
                                columns.ConstantColumn(col.Width);
                            }
                            else
                            {
                                columns.RelativeColumn(col.Width);
                            }
                        }
                    });

                    table.Header(header =>
                    {
                        foreach (var colItem in TableData.ColumnNames)
                        {
                            header.Cell().Element(CellStyle).Text(colItem.Name);
                        }

                        IContainer CellStyle(IContainer container) => DefaultCellStyle(container, Colors.Grey.Lighten3);
                    });

                    if (TableData.Data.Any())
                    {
                        foreach (var row in TableData.Data)
                        {
                            if (row.Any())
                            {
                                foreach (var data in row)
                                {
                                    table.Cell().Element(CellStyle).Text(data != null ? data.ToString() : "");


                                }
                            }
                        }
                    }

                    IContainer CellStyle(IContainer container) => DefaultCellStyle(container, Colors.White).ShowOnce();
                });
            });
        }

    }
}
