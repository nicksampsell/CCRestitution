namespace CCRestitution.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ModelName { get; set; }
        public List<ReportCriteria> ReportCriteria { get; set; } = new List<ReportCriteria>();
        public List<ReportField> ReportFields { get; set; } = new List<ReportField>();
    }
}
