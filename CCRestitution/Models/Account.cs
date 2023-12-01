using System.ComponentModel.DataAnnotations;

namespace CCRestitution.Models
{
    public class Account : BaseEntity
    {
        public int AccountId { get; set; }
        [Display(Name = "Case Number")]
        public int? CaseNumber { get; set; }
        [Display(Name = "Docket Number")]
        public string? Docket { get; set; }
        
        public string? Type { get; set; }
        [Display(Name = "Assigned Date")]
        public DateTime? AssignedDate { get; set; }
        [Display(Name = "Closed Date")]
        public DateTime? ClosedDate { get; set; }
        [Display(Name = "Arrest Date")]
        public DateTime? ArrestDate { get; set; }
        [Display(Name = "Agency Code")]
        public int? AgencyCode { get; set; }
        [Display(Name = "Custody Status")]
        public string? CustodyStatus { get; set; }
        public List<Crime> Crimes { get; set; } = new List<Crime>();
        public List<Defendant> Defendants { get; set; } = new List<Defendant>();
        public List<Victim> Victims { get; set; } = new List<Victim>();
        public int? CourtId { get; set; }
        public Court? Court { get; set; }
        public int? JudgeId { get; set; }
        public Judge? Judge { get; set; }

        public List<MoneyOrdered>? MoneyOrdered { get; set; }
        public List<Payment>? Payments { get; set; }
    }
}
