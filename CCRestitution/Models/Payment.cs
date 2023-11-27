namespace CCRestitution.Models
{
    public class Payment : BaseEntity
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public int? AccountNumber { get; set; }
        public DateTime? DatePaid { get; set; }
        public decimal? FineAmount { get; set; }
        public decimal? MandatorySurchargeAmount { get; set; }
        public decimal? EHMAmount { get; set; }
        public decimal? RestitutionAmount { get; set; }
        public decimal? SurchargeAmount { get; set; }
        public decimal? OtherAmount { get; set; }
        public decimal? SupervisionFee { get; set; }
        public string? Notes { get; set; }
    }
}
