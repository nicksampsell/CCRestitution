
namespace CCRestitution.Services.ReportsService
{
    public interface IReportsService
    {
        Task<byte[]?> BalanceMoneyReceivedAsync(int? userId, DateTime? runDate);
        Task<byte[]?> CheckProcessingReportAsync(DateTime? runDate);
        Task<byte[]?> CheckReconAsync(bool sortByDate = false);
        Task<byte[]?> CrossFootTotalsAsync(DateTime? runDate);
        Task<byte[]?> DepositReportAsync(DateTime? runDate);
        Task<byte[]?> FindMOReceiptAsync(int? receiptId, DateTime? ReceiptDate, int? checkNumber, int? supvFeeId, DateTime? supvFeeDate);
        Task<byte[]?> GenerateAccountsAssignedToIndividual(int UserId);
        Task<byte[]?> GenerateCasesClosedByCrimeCrossTabAsync(DateTime startDate, DateTime endDate);
        Task<byte[]?> GenerateCollectionsByCourtAsync(DateTime startDate, DateTime endDate);
        Task<byte[]?> GenerateCourtNotificationPaidInFullLetterAsync(int accountNumber);
        Task<byte[]?> GenerateDANotificationPaidInFullLetterAsync(int accountNumber);
        Task<byte[]?> GenerateDisbursementsByCourtAsync(DateTime startDate, DateTime endDate);
        Task<byte[]?> GenerateDPCA30AAsync(DateTime runDate, DateTime startDate, DateTime endDate);
        Task<byte[]?> GenerateEMMonthlyFeesCollectedAsync(DateTime? startdate);
        Task<byte[]?> GenerateEnvelopesAsync(DateTime? runDate);
        Task<byte[]?> GenerateFinalRestitutionPaymentLetterAsync(int accountNumber);
        Task<byte[]?> GenerateMonthlyDSSReportAsync(DateTime? startDate);
        Task<byte[]?> GenerateNumAccountsInCriminalCourt(DateTime startDate, DateTime endDate, bool opened = false);
        Task<byte[]?> GenerateNumAccountsInFamilyCourtAsync(DateTime startDate, DateTime endDate, bool opened = false);
        Task<byte[]?> GenerateNumAccountsOpenedInFamilyCourtAsync(DateTime startDate, DateTime endDate, bool opened = false);
        Task<byte[]?> GeneratePartialPaymentLetterAsync(int accountNumber);
        Task<byte[]?> GeneratePORestitutionListAsync(DateTime? startDate);
        Task<byte[]?> GenerateRestitutionByCrimeReportAsync(DateTime startDate, DateTime endDate, bool opened = false);
        Task<byte[]?> GenerateRestitutionReportAsync(DateTime startDate, DateTime endDate, bool opened = false);
        Task<byte[]?> LogDiscTransMoAsync(DateTime? startdate, DateTime? endDate);
        Task<byte[]?> LogMoneyOrderedAsync(DateTime? startdate, DateTime? endDate);
        Task<byte[]?> MonthlyChangeLogAsync(DateTime? startdate, DateTime? endDate);
        Task<byte[]?> MOPOCollectedAsync(int userId, DateTime? runDate);
        Task<byte[]?> MOPODischargedAsync(int userId, DateTime? runDate);
        Task<byte[]?> SupvFeeYTDStatusAsync(DateTime? runDate);
        Task<byte[]?> SupvFeeYTDStatusDetailAsync(DateTime? runDate);
        Task<byte[]?> VerifyAmountsDiffAsync(DateTime? runDate);
        Task<byte[]?> VerifyTotalsPaidAsync(DateTime? runDate);
        Task<byte[]?> VictimCheckRunAsync(DateTime? runDate, int startCheckNum);
    }
}