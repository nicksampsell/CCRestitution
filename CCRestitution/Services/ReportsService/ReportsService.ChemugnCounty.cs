using CCRestitution.Data;
using CCRestitution.ReportsRepository;
using Microsoft.Identity.Client;
using QuestPDF.Infrastructure;

namespace CCRestitution.Services.ReportsService
{
    public partial class ReportsService : IReportsService
    {
        private readonly DataContext _context;
        private readonly ILogger<ReportsService> _logger;

        public ReportsService(DataContext dataContext, ILogger<ReportsService> logger)
        {
            _context = dataContext;
            _logger = logger;
        }

        public async Task<IDocument?> GeneratePartialPaymentLetterAsync(int accountNumber)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> GenerateFinalRestitutionPaymentLetterAsync(int accountNumber)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> GenerateDANotificationPaidInFullLetterAsync(int accountNumber)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> GenerateCourtNotificationPaidInFullLetterAsync(int accountNumber)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> GenerateRestitutionReportAsync(DateTime startDate, DateTime endDate, bool opened = false)
        {
            //handle both opened or closed
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> GenerateRestitutionByCrimeReportAsync(DateTime startDate, DateTime endDate, bool opened = false)
        {
            //handle both opened or closed
            IDocument? result = null;
            return result;


        }

        public async Task<IDocument?> GeneratePORestitutionListAsync(DateTime? startDate)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> GenerateMonthlyDSSReportAsync(DateTime? startDate)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> GenerateEMMonthlyFeesCollectedAsync(DateTime? startdate)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> GenerateDPCA30AAsync(DateTime runDate, DateTime startDate, DateTime endDate)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> GenerateCasesClosedByCrimeCrossTabAsync(DateTime startDate, DateTime endDate)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> GenerateCollectionsByCourtAsync(DateTime startDate, DateTime endDate)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> GenerateDisbursementsByCourtAsync(DateTime startDate, DateTime endDate)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> GenerateNumAccountsOpenedInFamilyCourtAsync(DateTime startDate, DateTime endDate, bool opened = false)
        {
            //handle both opened or closed
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> GenerateNumAccountsInFamilyCourtAsync(DateTime startDate, DateTime endDate, bool opened = false)
        {
            //handle both opened or closed
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> GenerateNumAccountsInCriminalCourt(DateTime startDate, DateTime endDate, bool opened = false)
        {
            //handle both opened or closed
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> GenerateAccountsAssignedToIndividual(int UserId)
        {
            IDocument? result = null;
            return result;
        }

    }
}
