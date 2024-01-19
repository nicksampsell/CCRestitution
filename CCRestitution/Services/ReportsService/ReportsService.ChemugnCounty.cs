using CCRestitution.Data;
using CCRestitution.ReportsRepository;
using Microsoft.Identity.Client;

namespace CCRestitution.Services.ReportsService
{
    public partial class ReportsService : IReportsService
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<ReportsService> _logger;

        public ReportsService(DataContext dataContext, ILogger<ReportsService> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public async Task<byte[]?> GeneratePartialPaymentLetterAsync(int accountNumber)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> GenerateFinalRestitutionPaymentLetterAsync(int accountNumber)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> GenerateDANotificationPaidInFullLetterAsync(int accountNumber)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> GenerateCourtNotificationPaidInFullLetterAsync(int accountNumber)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> GenerateRestitutionReportAsync(DateTime startDate, DateTime endDate, bool opened = false)
        {
            //handle both opened or closed
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> GenerateRestitutionByCrimeReportAsync(DateTime startDate, DateTime endDate, bool opened = false)
        {
            //handle both opened or closed
            byte[]? result = null;
            return result;


        }

        public async Task<byte[]?> GeneratePORestitutionListAsync(DateTime? startDate)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> GenerateMonthlyDSSReportAsync(DateTime? startDate)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> GenerateEMMonthlyFeesCollectedAsync(DateTime? startdate)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> GenerateDPCA30AAsync(DateTime runDate, DateTime startDate, DateTime endDate)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> GenerateCasesClosedByCrimeCrossTabAsync(DateTime startDate, DateTime endDate)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> GenerateCollectionsByCourtAsync(DateTime startDate, DateTime endDate)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> GenerateDisbursementsByCourtAsync(DateTime startDate, DateTime endDate)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> GenerateNumAccountsOpenedInFamilyCourtAsync(DateTime startDate, DateTime endDate, bool opened = false)
        {
            //handle both opened or closed
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> GenerateNumAccountsInFamilyCourtAsync(DateTime startDate, DateTime endDate, bool opened = false)
        {
            //handle both opened or closed
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> GenerateNumAccountsInCriminalCourt(DateTime startDate, DateTime endDate, bool opened = false)
        {
            //handle both opened or closed
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> GenerateAccountsAssignedToIndividual(int UserId)
        {
            byte[]? result = null;
            return result;
        }

    }
}
