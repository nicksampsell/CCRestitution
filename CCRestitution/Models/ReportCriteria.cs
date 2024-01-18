namespace CCRestitution.Models
{
    public class ReportCriteria
    {
        public int ReportCriteriaId { get; set; }
        public int ReportId { get; set; }
        public Report? Report { get; set; }
        public string? Field { get; set; }
        public string? Operator { get; set; }
        public string? FieldValue { get; set; }
        public string? RawQuery { get; set; }
        public string? OrFields { get; set; }
    }
}
