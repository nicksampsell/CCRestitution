﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCRestitution.Models
{
    public class Court : BaseEntity
    {
        public int CourtId { get; set; }
        public string? Title { get; set; }
        [Display(Name="Street Address")]
        public string? Address { get; set; }
        [Display(Name ="Suite, Floor, etc. (Optional)")]
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        [Display(Name ="Zip Code")]
        public string? ZipCode { get; set; }
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }
        [Display(Name = "Fax Number")]
        public string? Fax { get; set; }
        public List<Judge>? Judges { get; set; }
    }
}
