namespace CCRestitution.PdfImplementation.DocumentModels
{
    public class CheckModel
    {
        public int CheckNumber { get; set; }
        public DateTime CheckDate { get; set; }
        public string PayToTheOrderOf { get; set; }
        public string AmountNumeral { get; set; }
        public string AmountWords { get; set; }
        public string Memo { get; set; }

    }
}
