using System;
using System.ComponentModel.DataAnnotations;

namespace CCRestitution.Models
{
    public class VictimPriorResidence
    {
        public int VictimPriorResidenceId { get; set; }
        public int? VictimId { get; set; }
        public Victim? Victim { get; set; }
        [Display(Name = "Street Address")]
        public string? Address { get; set; }
        [Display(Name = "Suite, Floor, etc. (Optional)")]
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        [Display(Name = "Zip Code")]
        public string? ZipCode { get; set; }

        [Display(Name = "Beginning Date")]
        public DateTime FromDT { get; set; }
        [Display(Name = "Ending Date")]
        public DateTime ToDT { get; set; }
        [Display(Name = "Lived With")]
        public string WithName { get; set; }
        [Display(Name = "Relationship")]
        public string WithRelationship { get; set; }
        [Display(Name = "Reason Left")]
        public string ReasonLeft { get; set; }
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

    }
}
