namespace CCRestitution.ReportsInterface
{
    public interface IMonthyReportsRepository
    {
        public Task PartialPaymentLetter();
        public Task FinalRestitutionPaymentLetter();
        public Task OverPaymentLetter();
        public Task DANotificationPaidInFullLetter();
        public Task CourtNotificationPaidInFullLetter();
        public Task RestitutionCasesOpenedForMonth(int month, int year, int? endMonth, int? endYear);
        public Task RestitutionCasesClosedForMonth(int month, int year, int? endMonth, int? endYear);
        public Task RestitutionOpenedByCrime(int crime);
        public Task RestitutionClosedByCrime(int crime);
        public Task PORestitutionList();
        public Task MonthlyDSSReport(int month, int year, int? endMonth, int? endYear);
        public Task EMMonthyFeesCollected(int month, int year, int? endMonth, int? endYear);
    }
}
