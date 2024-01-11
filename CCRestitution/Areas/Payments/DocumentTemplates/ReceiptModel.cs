using CCRestitution.Models;
using CCRestitution.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCRestitution.Areas.Payments.DocumentTemplates
{
    public class ReceiptModel
    {
        public int PaymentId { get; set; }
        public string? ClerkName { get; set; }
        public string? PaidByName { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public DateTime? DatePaid { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? MandatorySurchargeAmount { get; set; }
        public decimal? EHMAmount { get; set; }
        public decimal? RestitutionAmount { get; set; }
        public decimal? SurchargeAmount { get; set; }
        public decimal? OtherAmount { get; set; }
        public decimal? SupervisionFee { get; set; }

        public List<MoneyDTO>? Restitutions { get; set; }
        public List<MoneyDTO>? MandatorySurcharges { get; set; }
        public List<MoneyDTO>? EHMs { get; set; }
        public List<MoneyDTO>? Fines { get; set; }
        public List<MoneyDTO>? Surcharges { get; set; }
        public List<MoneyDTO>? Miscs { get; set; }

    }
}
