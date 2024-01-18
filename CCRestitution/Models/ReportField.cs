namespace CCRestitution.Models
{
    public class ReportField
    {
        public int ReportFieldId { get; set; }
        public int ReportId { get; set; }
        public Report? Report { get; set; }
        public string? ModelName { get; set; }
        public string? FieldName { get; set; }
    }
}
