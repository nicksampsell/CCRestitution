namespace CCRestitution.Models
{
    public class Account : BaseEntity
    {
        public int AccountId { get; set; }
        public int CaseNumber { get; set; }
        public string Docket { get; set; }
        public string Type { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public DateTime ArrestDate { get; set; }
        public int AgencyCode { get; set; }
        public string CustodyStatus { get; set; }
        public List<Crime> Crimes { get; set; }
        public List<Defendant> Defendants { get; set; }
        public List<Victim> Victims { get; set; }
        public int CourtId { get; set; }
        public Court? Court { get; set; }
        public int? JudgeId { get; set; }
        public Judge? Judge { get; set; }

    }
}
