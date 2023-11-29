using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCRestitution.Models
{
    public class Defendant : BaseEntity
    {
        public int DefendantId { get; set; }
        [Display(Name ="First Name")]
        public string? FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        public string? Suffix { get; set; }
        [Display(Name = "Social Security Number")]
        public string? SSN { get; set; }
        [Display(Name = "Birth Date")]
        public DateTime? DOB { get; set; }
        public string? Sex { get; set; }
        [Display(Name = "Street Address")]
        public string? Address1 { get; set; }
        [Display(Name = "Apartment, Floor, Suite, etc (Optional)")]
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        [Display(Name = "Zip Code")]
        public string? ZipCode { get; set; }
        public int? LegacyCaseNumber { get; set; }
        public string? NYSID { get; set; }
        public string? FBI { get; set; }
        public string? Race { get; set; }
        public int? HeightFt { get; set; }
        public int? HeightIn { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Weight { get; set; }
        public int? EyeColor { get; set; }
        public string? HairColor { get; set; }
        public string? IdentifyingMarks { get; set; }
        public string? Citizenship { get; set; }
        public string? Birthplace { get; set; }
        public string? EthnicityOrigin { get; set; }
        public string? HIV { get; set; }
        public string? Notes { get; set; }
        public string? AltPhone { get; set; }
        public string? Phone { get; set; }
        public string? MaritalStatus { get; set; }
        public string? ICEStatus { get; set; }
        public string? CellPhone { get; set; }
        public string? MaidenName { get; set; }
        public string? DriverLicense { get; set; }
        public string? DriverLicenseClientId { get; set; }
        public string? AlertMessage { get; set; }
        public string? PictureLink { get; set; }
        public string? RegisteredSexOffenderLevel { get; set; }
        public DateTime? RegisteredSexOffenderDate { get; set; }
        public string? PhoneOtherName { get; set; }
        public string? MilitaryStatus { get; set; }
        public string? Employable { get; set; }
        public string? EducationLevel { get; set; }

        public List<DefendantPriorResidence> PriorResidences { get; set; } = new List<DefendantPriorResidence>();
        public List<Account> Accounts { get; set; } = new List<Account>();

        public string FullName
        {
            get
            {

                string _name;
                if(MiddleName != null)
                {
                    _name = $"{FirstName} {MiddleName} {LastName}";
                }
                else
                {
                    _name = $"{FirstName} {LastName}";
                }

                if(Suffix != null)
                {
                    _name = $"{_name} {Suffix}";
                }

                return _name;
            }
        }
        

    }
}
