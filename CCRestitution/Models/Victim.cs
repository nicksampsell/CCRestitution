using System.ComponentModel.DataAnnotations;

namespace CCRestitution.Models
{
    public class Victim : BaseEntity
    {
        public int VictimId { get; set; }
        [Display(Name = "Case Number")]
        public int CaseNumber { get; set; }
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Display(Name = "Street Address")]
        public string? Address { get; set; }
        [Display(Name = "Apartment, Suite, Floor, etc. (Optional)")]
        public string? Address2 { get; set; }
        public string? City { get; set; }
        [Display(Name = "Zip Code")]
        public string? ZipCode { get; set; }
        public string? Type { get; set; }
        [Display(Name = "Amount Due")]
        public decimal? AmountDue { get; set; }
        [Display(Name = "Amount Paid")]
        public decimal? AmountPaid { get; set; }
        public string? Notes { get; set; }
        public List<VictimPriorResidence> PriorResidences { get; set; } = new List<VictimPriorResidence>();
        public List<Account> Accounts { get; set; } = new List<Account>();

    }
}
