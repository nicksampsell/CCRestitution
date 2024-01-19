namespace CCRestitution.PdfImplementation.DocumentModels
{
    public class ReportDataModel
    {
        public string Title { get; set; } = String.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DateFormat { get; set; } = "Y";
        public bool DisplayDateAsSpan { get; set; } = false;
        public string UserName { get; set; } = String.Empty;
        public DateTime GeneratedDate { get; set; } = DateTime.Now;
        public string GeneratedDateFormat { get; set; } = "U";

    }
}
