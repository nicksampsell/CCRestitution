using CCRestitution.Data;

namespace CCRestitution.Services.ReportsService
{
    public partial class ReportsService : IReportsService
    {

        public async Task<byte[]?> LogDiscTransMoAsync(DateTime? startdate, DateTime? endDate)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> LogMoneyOrderedAsync(DateTime? startdate, DateTime? endDate)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> MonthlyChangeLogAsync(DateTime? startdate, DateTime? endDate)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> FindMOReceiptAsync(int? receiptId, DateTime? ReceiptDate, int? checkNumber, int? supvFeeId, DateTime? supvFeeDate)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> SupvFeeYTDStatusAsync(DateTime? runDate)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> SupvFeeYTDStatusDetailAsync(DateTime? runDate)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> CheckReconAsync(bool sortByDate = false)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> CrossFootTotalsAsync(DateTime? runDate)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> VerifyTotalsPaidAsync(DateTime? runDate)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> VerifyAmountsDiffAsync(DateTime? runDate)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> MOPOCollectedAsync(int userId, DateTime? runDate)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> MOPODischargedAsync(int userId, DateTime? runDate)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> BalanceMoneyReceivedAsync(int? userId, DateTime? runDate)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> DepositReportAsync(DateTime? runDate)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> CheckProcessingReportAsync(DateTime? runDate)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> VictimCheckRunAsync(DateTime? runDate, int startCheckNum)
        {
            byte[]? result = null;
            return result;
        }

        public async Task<byte[]?> GenerateEnvelopesAsync(DateTime? runDate)
        {
            byte[]? result = null;
            return result;
        }
    }
}
