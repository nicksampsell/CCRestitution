
using QuestPDF.Infrastructure;

namespace CCRestitution.Services.ReportsService
{
    public interface IReportsService
    {
        Task<IDocument?> BalanceMoneyReceivedAsync(int? userId, DateTime? runDate);
        Task<IDocument?> CheckProcessingReportAsync(DateTime? runDate);
        Task<IDocument?> CheckReconAsync(bool sortByDate = false);
        Task<IDocument?> CrossFootTotalsAsync(DateTime? runDate);
        Task<IDocument?> DepositReportAsync(DateTime? runDate);
        Task<IDocument?> FindMOReceiptAsync(int? receiptId, DateTime? ReceiptDate, int? checkNumber, int? supvFeeId, DateTime? supvFeeDate);
        Task<IDocument?> GenerateAccountsAssignedToIndividual(int UserId);
        Task<IDocument?> GenerateCasesClosedByCrimeCrossTabAsync(DateTime startDate, DateTime endDate);
        Task<IDocument?> GenerateCollectionsByCourtAsync(DateTime startDate, DateTime endDate);
        Task<IDocument?> GenerateCourtNotificationPaidInFullLetterAsync(int accountNumber);
        Task<IDocument?> GenerateDANotificationPaidInFullLetterAsync(int accountNumber);
        Task<IDocument?> GenerateDisbursementsByCourtAsync(DateTime startDate, DateTime endDate);
        Task<IDocument?> GenerateDPCA30AAsync(DateTime runDate, DateTime startDate, DateTime endDate);
        Task<IDocument?> GenerateEMMonthlyFeesCollectedAsync(DateTime? startdate);
        Task<IDocument?> GenerateEnvelopesAsync(DateTime? runDate);
        Task<IDocument?> GenerateFinalRestitutionPaymentLetterAsync(int accountNumber);
        Task<IDocument?> GenerateMonthlyDSSReportAsync(DateTime? startDate);
        Task<IDocument?> GenerateNumAccountsInCriminalCourt(DateTime startDate, DateTime endDate, bool opened = false);
        Task<IDocument?> GenerateNumAccountsInFamilyCourtAsync(DateTime startDate, DateTime endDate, bool opened = false);
        Task<IDocument?> GenerateNumAccountsOpenedInFamilyCourtAsync(DateTime startDate, DateTime endDate, bool opened = false);
        Task<IDocument?> GeneratePartialPaymentLetterAsync(int accountNumber);
        Task<IDocument?> GeneratePORestitutionListAsync(DateTime? startDate);
        Task<IDocument?> GenerateRestitutionByCrimeReportAsync(DateTime startDate, DateTime endDate, bool opened = false);
        Task<IDocument?> GenerateRestitutionReportAsync(DateTime startDate, DateTime endDate, bool opened = false);
        Task<IDocument?> LogDischTransMoAsync(DateTime? startdate, DateTime? endDate);
        Task<IDocument?> LogMoneyOrderedAsync(DateTime? startdate, DateTime? endDate);
        Task<IDocument?> MonthlyChangeLogAsync(DateTime? startdate, DateTime? endDate);
        Task<IDocument?> MOPOCollectedAsync(int userId, DateTime? runDate);
        Task<IDocument?> MOPODischargedAsync(int userId, DateTime? runDate);
        Task<IDocument?> SupvFeeYTDStatusAsync(DateTime? runDate);
        Task<IDocument?> SupvFeeYTDStatusDetailAsync(DateTime? runDate);
        Task<IDocument?> VerifyAmountsDiffAsync(DateTime? runDate);
        Task<IDocument?> VerifyTotalsPaidAsync(DateTime? runDate);
        Task<IDocument?> VictimCheckRunAsync(DateTime? runDate, int startCheckNum);
    }
}