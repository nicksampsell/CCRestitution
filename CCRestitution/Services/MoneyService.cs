using CCRestitution.Data;
using CCRestitution.Interfaces;
using Humanizer;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CCRestitution.Services
{
    public class MoneyService(DataContext context, ILogger<MoneyService> logger) : IMoneyService
    {
        private readonly DataContext _context = context;
        private readonly ILogger<MoneyService> _logger = logger;

        public async Task<List<MoneyAccountInfo>> GetAccountInfo(int AccountId)
        {
            _logger.LogInformation($"Return general information for {AccountId}");
            return await _context.MoneyOrdered.Where(x => x.AccountId == AccountId).Select(x => new MoneyAccountInfo
            {
                Id = x.MoneyOrderedId,
                AccountId = x.AccountId,
                DateClosed = x.DateClosed,
                DateOpened = x.DateOpened,
                Judgement = x.Judgement,
                SatisfactionDate = x.SatisfactionDate,
                LegacyAccountNumber = x.LegacyAccountNumber,
                Notes = x.Notes
            }).ToListAsync();
        }
        public async Task<List<MoneyDTO>?> GetRestitution(int AccountId)
        {
            _logger.LogInformation($"Return restitution items for {AccountId}");
            return await _context.MoneyOrdered.Where(x => x.AccountId == AccountId).Select(x => new MoneyDTO
            {
                DateOpened = x.RestitutionDateOpened,
                DateClosed = x.RestitutionClosedDate,
                LastPaidDate = x.RestitutionLastPayDate,
                PayByDate = x.RestitutionPayByDate,
                AmountPaid = x.RestitutionAmountPaid,
                Balance = x.RestitutionBalance,
                OriginalAmount = x.RestitutionAmount,
            }).ToListAsync();
        }

        public async Task<List<MoneyDTO>?> GetFine(int AccountId)
        {
            _logger.LogInformation($"Return fine items for {AccountId}");
            return await _context.MoneyOrdered.Where(x => x.AccountId == AccountId).Select(x => new MoneyDTO
            {
                DateOpened = x.FineOpenDate,
                DateClosed = x.FineClosedDate,
                LastPaidDate = x.FineLastPayDate,
                PayByDate = x.FinePayByDate,
                AmountPaid = x.FineAmountPaid,
                Balance = x.FineBalance,
                OriginalAmount = x.FineAmount
            }).ToListAsync();
        }

        public async Task<List<MoneyDTO>?> GetSurcharge(int AccountId)
        {
            _logger.LogInformation($"Return surcharge items for {AccountId}");
            return await _context.MoneyOrdered.Where(x => x.AccountId == AccountId).Select(x => new MoneyDTO
            {
                DateOpened = x.SurchargeOpenDate,
                DateClosed = x.SurchargeClosedDate,
                LastPaidDate = x.SurchargeLastPayDate,
                PayByDate = x.SurchargePayByDate,
                AmountPaid = x.SurchargeAmountPaid,
                Balance = x.SurchargeBalance,
                OriginalAmount = x.SurchargeAmount
            }).ToListAsync();
        }

        public async Task<List<MoneyDTO>?> GetMandatorySurcharge(int AccountId)
        {
            _logger.LogInformation($"Return mandatory surcharge items for {AccountId}");
            return await _context.MoneyOrdered.Where(x => x.AccountId == AccountId).Select(x => new MoneyDTO
            {
                DateOpened = x.MandatoryOpenDate,
                DateClosed = x.MandatoryClosedDate,
                LastPaidDate = x.MandatoryLastPayDate,
                PayByDate = x.MandatoryPayByDate,
                AmountPaid = x.MandatoryAmountPaid,
                Balance = x.MandatoryBalance,
                OriginalAmount = x.MandatoryAmount
            }).ToListAsync();
        }

        public async Task<List<MoneyDTO>?> GetDWI(int AccountId)
        {
            _logger.LogInformation($"Return DWI items for {AccountId}");
            return await _context.MoneyOrdered.Where(x => x.AccountId == AccountId).Select(x => new MoneyDTO
            {
                DateOpened = x.DWIOpenDate,
                DateClosed = x.DWIClosedDate,
                LastPaidDate = x.DWILastPayDate,
                PayByDate = x.DWIPayByDate,
                AmountPaid = x.DWIAmountPaid,
                Balance = x.DWIBalance,
                OriginalAmount = x.DWIAmount
            }).ToListAsync();
        }

        public async Task<List<MoneyDTO>?> GetMisc(int AccountId)
        {
            _logger.LogInformation($"Return misc items for {AccountId}");
            return await _context.MoneyOrdered.Where(x => x.AccountId == AccountId).Select(x => new MoneyDTO
            {
                DateOpened = x.MiscOpenDate,
                DateClosed = x.MiscClosedDate,
                LastPaidDate = x.MiscLastPayDate,
                PayByDate = x.MiscPayByDate,
                AmountPaid = x.MiscAmountPaid,
                Balance = x.MiscBalance,
                OriginalAmount = x.MiscAmountPaid
            }).ToListAsync();
        }

        public async Task<List<MoneyDTO>?> GetCVAF(int AccountId)
        {
            _logger.LogInformation($"Return CVAF items for {AccountId}");
            return await _context.MoneyOrdered.Where(x => x.AccountId == AccountId).Select(x => new MoneyDTO
            {
                DateOpened = null,
                DateClosed = null,
                LastPaidDate = null,
                PayByDate = null,
                AmountPaid = x.CVAFAmountPaid,
                Balance = x.CVAFBalance,
                OriginalAmount = x.CVAFAmount
            }).ToListAsync();
        }

        public async Task setValue(int id, MoneyUpdateObject update)
        {
            var acct = await _context.MoneyOrdered.Where(x => x.MoneyOrderedId == id).FirstOrDefaultAsync();

            if (acct == null)
            {
                return;
            }

            switch (update.MoneyObjectType)
            {
                case MoneyOrderedTypes.Restitution:
                    acct.RestitutionLastPayDate = update.LastPaidDate;
                    acct.RestitutionBalance -= update.Amount;
                    acct.RestitutionAmountPaid += update.Amount;

                    if (acct.RestitutionBalance <= 0)
                    {
                        acct.RestitutionClosedDate = DateTime.Now;
                    }

                    break;
                case MoneyOrderedTypes.Surcharge:
                    acct.SurchargeLastPayDate = update.LastPaidDate;
                    acct.SurchargeBalance -= update.Amount;
                    acct.SurchargeAmountPaid += update.Amount;

                    if (acct.SurchargeBalance <= 0)
                    {
                        acct.SurchargeClosedDate = DateTime.Now;
                    }

                    break;
                case MoneyOrderedTypes.MandatorySurcharge:
                    acct.MandatoryLastPayDate = update.LastPaidDate;
                    acct.MandatoryBalance -= update.Amount;
                    acct.MandatoryAmountPaid += update.Amount;

                    if (acct.MandatoryBalance <= 0)
                    {
                        acct.MandatoryClosedDate = DateTime.Now;
                    }

                    break;
                case MoneyOrderedTypes.Fine:
                    acct.FineLastPayDate = update.LastPaidDate;
                    acct.FineBalance -= update.Amount;
                    acct.FineAmountPaid += update.Amount;

                    if (acct.FineBalance <= 0)
                    {
                        acct.FineClosedDate = DateTime.Now;
                    }

                    break;
                case MoneyOrderedTypes.DWI:
                    acct.DWILastPayDate = update.LastPaidDate;
                    acct.DWIBalance -= update.Amount;
                    acct.DWIAmountPaid += update.Amount;

                    if (acct.DWIBalance <= 0)
                    {
                        acct.DWIClosedDate = DateTime.Now;
                    }

                    break;
                case MoneyOrderedTypes.CVAF:
                    acct.CVAFLastPayDate = update.LastPaidDate;
                    acct.CVAFBalance -= update.Amount;
                    acct.CVAFAmountPaid += update.Amount;

                    //CVAF does not have a closed date field.

                    break;
                case MoneyOrderedTypes.Misc:
                    acct.MiscLastPayDate = update.LastPaidDate;
                    acct.MiscBalance -= update.Amount;
                    acct.MiscAmountPaid += update.Amount;

                    if (acct.MiscBalance <= 0)
                    {
                        acct.MiscClosedDate = DateTime.Now;
                    }

                    break;
                default:
                    //do nothing
                    break;
            }
        }
    }




    public class MoneyAccountInfo
    {
        public int? Id { get; set; }
        public int? AccountId { get; set; }
        public int? LegacyAccountNumber { get; set; }
        public DateTime? DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }
        public DateTime? SatisfactionDate { get; set; }
        public string? Notes { get; set; }
        public string? Judgement { get; set; }
    }
    public class MoneyDTO
    {
        public DateTime? DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }
        public DateTime? PayByDate { get; set; }
        public DateTime? LastPaidDate { get; set; }
        public decimal? OriginalAmount { get; set; }
        public decimal? LastPaidAmount { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? Balance { get; set; }
    }

    public class MoneyUpdateObject
    {
        public DateTime LastPaidDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; } = 0m;
        public MoneyOrderedTypes MoneyObjectType { get; set; }
    }

    public enum MoneyOrderedTypes
    {
        Restitution,
        Fine,
        Surcharge,
        MandatorySurcharge,
        DWI,
        Misc,
        CVAF
    }
}
