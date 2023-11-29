using CCRestitution.Data;
using CCRestitution.ReportsInterface;

namespace CCRestitution.ReportsRepository
{
    public class MonthyReportsRepository : IMonthyReportsRepository
    {
        private readonly DataContext _context;

        public MonthyReportsRepository(DataContext context)
        {
            _context = context;
        }

        public Task CourtNotificationPaidInFullLetter()
        {
            throw new NotImplementedException();
        }

        public Task DANotificationPaidInFullLetter()
        {
            throw new NotImplementedException();
        }

        public Task EMMonthyFeesCollected(int month, int year, int? endMonth, int? endYear)
        {
            throw new NotImplementedException();
        }

        public Task FinalRestitutionPaymentLetter()
        {
            throw new NotImplementedException();
        }

        public Task MonthlyDSSReport(int month, int year, int? endMonth, int? endYear)
        {
            throw new NotImplementedException();
        }

        public Task OverPaymentLetter()
        {
            throw new NotImplementedException();
        }

        public async Task PartialPaymentLetter()
        {

        }

        public Task PORestitutionList()
        {
            throw new NotImplementedException();
        }

        public Task RestitutionCasesClosedForMonth(int month, int year, int? endMonth, int? endYear)
        {
            throw new NotImplementedException();
        }
        public Task RestitutionCasesOpenedForMonth(int month, int year, int? endMonth, int? endYear)
        {
            throw new NotImplementedException();
        }

        public Task RestitutionClosedByCrime(int crime)
        {
            throw new NotImplementedException();
        }

        public Task RestitutionOpenedByCrime(int crime)
        {
            throw new NotImplementedException();
        }
    }
}
