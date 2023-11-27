using System.ComponentModel.DataAnnotations;

namespace CCRestitution.Models
{
    public class MoneyOrdered : BaseEntity
    {
        public int MoneyOrderedId { get; set; }
        public string AccountNumber { get; set; }
        public DateTime? Opened { get; set; }
        public DateTime? Closed { get; set;}
        [Display(Name = "Has EHM?")]
        public bool EHM { get; set; } = false;
        [Display(Name = "Fine Amount")]
        public decimal? FineAmount { get; set; }
        public DateTime? FineOpenDate { get; set; }
        public DateTime? FinePayByDate { get; set; }
        public DateTime? FineCloseDate { get; set; }
        [Display(Name = "Mandatory Surcharge Amount")]
        public decimal? MandatorySurchargeAmount { get; set; }
        public DateTime? MandatorySurchargeOpenDate { get; set; }
        public DateTime? MandatorySurchargePayByDate { get; set; }
        public DateTime? MandatorySurchargeCloseDate { get; set; }
        [Display(Name = "EHM Amount")]
        public decimal? EHMAmount { get; set; }
        [Display(Name = "Restitution Amount")]
        public decimal? RestitutionAmount { get; set; }
        public DateTime? RestitutionOpenDate { get; set; }
        public DateTime? RestitutionPayByDate { get; set; }
        public DateTime? RestitutionCloseDate { get; set; }
        [Display(Name = "Other Amount")]
        public decimal? OtherAmount { get; set; }
        public DateTime? OtherOpenDate { get; set; }
        public DateTime? OtherPayByDate { get; set; }
        public DateTime? OtherCloseDate { get; set; }
        [Display(Name = "5% Surcharge Amount")]
        public decimal SurchargeAmount { get; set; }
        public DateTime? SurchargeOpenDate { get; set; }
        public DateTime? SurchargePayByDate { get; set; }
        public DateTime SurchargeCloseDate { get; set; }
        [Display(Name = "Supervision Fee Amount")]
        public decimal? SupervisionFeeAmount { get; set; }
        public DateTime? SupervisionFeeOpenDate { get; set; }
        public DateTime? SupervisionFeeCloseDate { get; set; }
        public bool YO { get; set; } = false;
        public string Notes { get; set; }


    }
}
