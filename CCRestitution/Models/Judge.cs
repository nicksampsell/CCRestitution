using System.ComponentModel.DataAnnotations;

namespace CCRestitution.Models
{
    public class Judge : BaseEntity
    {
        public int JudgeId { get; set; }
        [Display(Name ="First Name")]
        public string? FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }
        [Display(Name ="Last Name")]
        public string? LastName { get; set; }
        [Display(Name = "Court")]
        public int? CourtId { get; set; }
        public Court? Court { get; set; }


        public string FullName => $"{FirstName} {MiddleName} {LastName}";
    }
}
