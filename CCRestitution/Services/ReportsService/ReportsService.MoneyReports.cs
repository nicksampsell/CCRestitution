using CCRestitution.Data;
using CCRestitution.PdfImplementation.DocumentModels;
using CCRestitution.ReportsRepository;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;

namespace CCRestitution.Services.ReportsService
{
    public partial class ReportsService : IReportsService
    {

        public async Task<IDocument?> LogDischTransMoAsync(DateTime? startdate, DateTime? endDate)
        {

            if(endDate == null)
            {
                endDate = DateTime.Now;
            }

            var data = await _context.MoneyOrdered.Include(x => x.Account).ThenInclude(x => x.Defendants).Include(x => x.Account).ThenInclude(x => x.Court).Where(x => x.RestitutionDateOpened <= startdate && (x.RestitutionClosedDate >= endDate || x.RestitutionClosedDate == null)).Select(x => new List<string>
            {
                x.Account.Defendants.Select(x => x.FullName).FirstOrDefault(),
                x.Account.AccountId.ToString() ?? "",
                x.Account.CaseNumber.ToString() ?? "",
                "",
                "",
                x.Account.Court.Title.ToString() ?? "",
                "",
                "",
                "",
                "",
                "",
                ""
            }).ToListAsync();
            var report = new SimpleTableReport(
            
                new ReportDataModel() { 
                    Title = "Log Discharge/Trans MO",
                    StartDate = startdate.GetValueOrDefault(),
                    EndDate = endDate.GetValueOrDefault(),
                    DisplayDateAsSpan = true,
                    Margin = 0.25f,
                    Orientation = ReportOrientation.Landscape
                    
                },
                new TableReportModel()
                {
                    ColumnNames = {
                        new ColumnDefinition("Name" , "Constant", 100),
                        new ColumnDefinition("Account No"),
                        new ColumnDefinition("Case No"),
                        new ColumnDefinition("PO Assigned"),
                        new ColumnDefinition("Prob Dt"),
                        new ColumnDefinition("Conv. Court"),
                        new ColumnDefinition("Type"),
                        new ColumnDefinition("Disc. Type"),
                        new ColumnDefinition("Dt"),
                        new ColumnDefinition("Trans Out Accepted"),
                        new ColumnDefinition("To"),
                        new ColumnDefinition("Jurisdiction Type"),
                    },
                    Data = data,
                    FooterContent = ""
                }
            );


            return report;
        }

        public async Task<IDocument?> LogMoneyOrderedAsync(DateTime? startdate, DateTime? endDate)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> MonthlyChangeLogAsync(DateTime? startdate, DateTime? endDate)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> FindMOReceiptAsync(int? receiptId, DateTime? ReceiptDate, int? checkNumber, int? supvFeeId, DateTime? supvFeeDate)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> SupvFeeYTDStatusAsync(DateTime? runDate)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> SupvFeeYTDStatusDetailAsync(DateTime? runDate)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> CheckReconAsync(bool sortByDate = false)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> CrossFootTotalsAsync(DateTime? runDate)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> VerifyTotalsPaidAsync(DateTime? runDate)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> VerifyAmountsDiffAsync(DateTime? runDate)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> MOPOCollectedAsync(int userId, DateTime? runDate)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> MOPODischargedAsync(int userId, DateTime? runDate)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> BalanceMoneyReceivedAsync(int? userId, DateTime? runDate)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> DepositReportAsync(DateTime? runDate)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> CheckProcessingReportAsync(DateTime? runDate)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> VictimCheckRunAsync(DateTime? runDate, int startCheckNum)
        {
            IDocument? result = null;
            return result;
        }

        public async Task<IDocument?> GenerateEnvelopesAsync(DateTime? runDate)
        {
            IDocument? result = null;
            return result;
        }
    }
}
