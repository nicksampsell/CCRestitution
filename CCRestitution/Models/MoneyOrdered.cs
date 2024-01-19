using System;
using System.ComponentModel.DataAnnotations;

namespace CCRestitution.Models
{
    public class MoneyOrdered : BaseEntity
    {
        public int MoneyOrderedId { get; set; }
        public int? AccountId { get; set; }
        public Account? Account { get; set; }
        public int? LegacyAccountNumber { get; set; }
        public DateTime? DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }
        public decimal? RestitutionAmount { get; set; }
        public DateTime? RestitutionDateOpened { get; set; }
        public DateTime? RestitutionClosedDate { get; set; }
        public DateTime? RestitutionPayByDate { get; set; }
        public decimal? RestitutionAmountPaid { get; set; }
        public DateTime? RestitutionLastPayDate { get; set; }
        public decimal? RestitutionBalance { get; set; }
        public decimal? FineAmount { get; set; }
        public DateTime? FineOpenDate { get; set; }
        public DateTime? FineClosedDate { get; set; }
        public DateTime? FinePayByDate { get; set; }
        public decimal? FineAmountPaid { get; set; }
        public DateTime? FineLastPayDate { get; set; }
        public decimal? FineBalance { get; set; }
        public decimal? SurchargeAmount { get; set; }
        public DateTime? SurchargeOpenDate { get; set; }
        public DateTime? SurchargeClosedDate { get; set; }
        public DateTime? SurchargePayByDate { get; set; }
        public decimal? SurchargeAmountPaid { get; set; }
        public DateTime? SurchargeLastPayDate { get; set; }
        public decimal? SurchargeBalance { get; set; }
        public decimal? MandatoryAmount { get; set; }
        public DateTime? MandatoryOpenDate { get; set; }
        public DateTime? MandatoryClosedDate { get; set; }
        public DateTime? MandatoryPayByDate { get; set; }
        public decimal? MandatoryAmountPaid { get; set; }
        public DateTime? MandatoryLastPayDate { get; set; }
        public decimal? MandatoryBalance { get; set; }
        public decimal? DWIAmount { get; set; }
        public DateTime? DWIOpenDate { get; set; }
        public DateTime? DWIClosedDate { get; set; }
        public DateTime? DWIPayByDate { get; set; }
        public decimal? DWIAmountPaid { get; set; }
        public DateTime? DWILastPayDate { get; set; }
        public decimal? DWIBalance { get; set; }
        public int? DWIOldAccount { get; set; }
        public decimal? MiscAmount { get; set; }
        public DateTime? MiscOpenDate { get; set; }
        public DateTime? MiscClosedDate { get; set; }
        public DateTime? MiscPayByDate { get; set; }
        public decimal? MiscAmountPaid { get; set; }
        public DateTime? MiscLastPayDate { get; set; }
        public decimal? MiscBalance { get; set; }
        public decimal? CVAFAmount { get; set; }
        public decimal? CVAFAmountPaid { get; set; }
        public decimal? CVAFBalance { get; set; }
        public DateTime? CVAFLastPayDate { get; set; }
        public string? Judgement { get; set; }
        public string? Notes { get; set; }
        public string? Group { get; set; }
        public string? RecNo { get; set; }
        public decimal? DWIArrears { get; set; }
        public decimal? DWIFeeTd { get; set; }
        public decimal? DWIPaidTd { get; set; }
        public decimal? DWIFW { get; set; }
        public DateTime? SatisfactionDate { get; set; }


    }
}
