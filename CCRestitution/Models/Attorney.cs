using System.ComponentModel.DataAnnotations;

namespace CCRestitution.Models
{
    public class Attorney
    {
        public int AttorneyId { get; set; }
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Display(Name = "Street Address")]
        public string? Address { get; set; }
        [Display(Name = "Suite, Floor, etc. (Optional)")]
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        [Display(Name = "Zip Code")]
        public string? ZipCode { get; set; }
        [Display(Name = "Email Address")]
        public string? Email { get; set; }
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }
        [Display(Name = "Fax Number")]
        public string? Fax { get; set; }
    }
}
