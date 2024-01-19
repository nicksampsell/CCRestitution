using SkiaSharp;

namespace CCRestitution.PdfImplementation.DocumentModels
{
    public class TableReportModel
    {
        public string TableName { get; set; } = string.Empty;
        public List<ColumnDefinition> ColumnNames { get; set; }= new List<ColumnDefinition>();
        public List<List<string>> Data { get; set; } = new List<List<string>>();
        public string FooterContent { get; set; } = string.Empty;
    }

    public class ColumnDefinition {
        public string Name { get; set; } = String.Empty;
        public string Type { get; set; } = "Relative";
        public float Width { get; set; } = 1;

        public ColumnDefinition(string name, string type = "Relative", float width = 1) 
        {
            Name = name;
            Type = type;
            Width = width;
        }

        public ColumnDefinition() { }

    }
}
