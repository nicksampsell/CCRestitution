using System.ComponentModel.DataAnnotations;

namespace CCRestitution.Models
{
    public class Defendant : BaseEntity
    {
        public int DefendantId { get; set; }
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Display(Name = "Suffix (e.g., Jr, Sr, III, etc.)")]
        public string? Suffix { get; set; }
        [Display(Name = "Social Security Number")]
        public string? SSN { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime? DOB { get; set; }
        public string? Sex { get; set; }
        [Display(Name = "Street Address")]
        public string? Address1 { get; set; }
        [Display(Name = "Apartment, Suite, Floor, etc (Optional)")]
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        [Display(Name ="Zip Code")]
        public string? ZipCode { get; set; }

        public List<DefendantPriorResidence> PriorResidences { get; set; }

    }
}
