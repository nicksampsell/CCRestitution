using System.ComponentModel.DataAnnotations;

namespace CCRestitution.Models
{
    public class Payment : BaseEntity
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        [Display(Name = "Account Number")]
        public int? AccountId { get; set; }

        public Account? Account { get; set; }
        [Display(Name = "Payment Date")]
        public DateTime? DatePaid { get; set; }
        [Display(Name = "Amount Towards Fine")]
        public decimal? FineAmount { get; set; }
        [Display(Name = "Amount Towards Mandatory Surcharge")]
        public decimal? MandatorySurchargeAmount { get; set; }
        [Display(Name = "Amount Towards EHM")]
        public decimal? EHMAmount { get; set; }
        [Display(Name = "Amount Towards Restitution")]
        public decimal? RestitutionAmount { get; set; }
        [Display(Name = "Amount Towards 5% Surcharge")]
        public decimal? SurchargeAmount { get; set; }
        [Display(Name = "Amount Towards Other Charges")]
        public decimal? OtherAmount { get; set; }
        [Display(Name = "Amount Towards Supervision Fee")]
        public decimal? SupervisionFee { get; set; }
        public string? Notes { get; set; }
    }
}
