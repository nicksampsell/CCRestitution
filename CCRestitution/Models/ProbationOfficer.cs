using System.ComponentModel.DataAnnotations;

namespace CCRestitution.Models
{
    public class ProbationOfficer
    {
        public int ProbationOfficerId { get; set; }
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Display(Name = "Position")]
        public string? Position { get; set; }
        [Display(Name = "Email Address")]
        public string? Email { get; set; }

        [Display(Name = "Assigned Department")]
        public int? ProbationDepartmentId { get; set; }
        public ProbationDepartment? ProbationDepartment { get; set; }

    }
}
