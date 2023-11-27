namespace CCRestitution.Models
{
    public class MoneyOrdered : BaseEntity
    {
        public int MoneyOrderedId { get; set; }
        public string AccountNumber { get; set; }
        public DateTime? Opened { get; set; }
        public DateTime? Closed { get; set;}
        public bool EHM { get; set; } = false;
        public decimal? FineAmount { get; set; }
        public DateTime? FineOpenDate { get; set; }
        public DateTime? FinePayByDate { get; set; }
        public DateTime? FineCloseDate { get; set; }
        public decimal? MandatorySurchargeAmount { get; set; }
        public DateTime? MandatorySurchargeOpenDate { get; set; }
        public DateTime? MandatorySurchargePayByDate { get; set; }
        public DateTime? MandatorySurchargeCloseDate { get; set; }
        public decimal? EHMAmount { get; set; }
        public decimal? RestitutionAmount { get; set; }
        public DateTime? RestitutionOpenDate { get; set; }
        public DateTime? RestitutionPayByDate { get; set; }
        public DateTime? RestitutionCloseDate { get; set; }
        public decimal? OtherAmount { get; set; }
        public DateTime? OtherOpenDate { get; set; }
        public DateTime? OtherPayByDate { get; set; }
        public DateTime? OtherCloseDate { get; set; }
        public decimal SurchargeAmount { get; set; }
        public DateTime? SurchargeOpenDate { get; set; }
        public DateTime? SurchargePayByDate { get; set; }
        public DateTime SurchargeCloseDate { get; set; }
        public decimal? SupervisionFeeAmount { get; set; }
        public DateTime? SupervisionFeeOpenDate { get; set; }
        public DateTime? SupervisionFeeCloseDate { get; set; }
        public bool YO { get; set; } = false;
        public string Notes { get; set; }


    }
}
