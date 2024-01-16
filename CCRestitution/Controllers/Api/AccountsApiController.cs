using CCRestitution.Data;
using CCRestitution.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Pagination.EntityFrameworkCore.Extensions;
using System.Collections.Generic;

namespace CCRestitution.Controllers.Api
{
    [Route("api/Accounts")]
    [ApiController]
    public class AccountsApiController : ControllerBase
    {
        private readonly DataContext _context;

        public AccountsApiController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("Search")]
        public async Task<PaginationResultset> Search(string search, int page = 1, int perPage = 100, bool nopage = false)
        {
            var results = _context.Accounts.Include(x => x.MoneyOrdered).Include(x => x.Payments).Include(x => x.Defendants).Where(x => x.Defendants.Any(y => y.FirstName.Contains(search) || y.LastName.Contains(search)) || x.Docket.Contains(search)).Select(x => new AccountSearchDTO
            {
                AccountId = x.AccountId,
                Docket = x.Docket,
                Defendants = x.Defendants.Select(y => new AccountSearchDefendant { FullName = $"{y.FirstName} {y.MiddleName} {y.LastName}", DefendantId = y.DefendantId }).ToList(),
                MoneyOrdered = x.MoneyOrdered.Select(y => new MoneyOrdered
                {
                    FineAmount = y.FineAmount,
                    MandatoryAmount = y.MandatoryAmount,
                    MiscAmount = y.MiscAmount,
                    RestitutionAmount = y.RestitutionAmount,
                    DWIAmount = y.DWIAmount,
                    CVAFAmount = y.CVAFAmount,
                    SurchargeAmount = y.SurchargeAmount,
                    Notes = y.Notes
                }).ToList(),
                LastPayment = x.Payments.OrderByDescending(x => x.Created).Take(1).Select(y => new LastPayment
                {
                    PaymentId = y.PaymentId,
                    DefendantId = y.DefendantId,
                    FineAmount = y.FineAmount,
                    MandatoryAmount = y.MandatorySurchargeAmount,
                    SurchargeAmount = y.SurchargeAmount,
                    MiscAmount = y.OtherAmount,
                    EHMAnount = y.EHMAmount,
                    Created = y.Created
                }).FirstOrDefault()
            }).AsQueryable();

            if (nopage)
            {
                return new PaginationResultset
                {
                    Results = await results.ToListAsync(),
                    Options = await results.ToListAsync(),
                    HasMore = false,
                    Page = page,
                    PerPage = await results.CountAsync(),
                };
            }
            else
            {
                return new PaginationResultset
                {
                    Results = await results.Skip((page - 1) * perPage).Take(perPage).ToListAsync(),
                    Options = await results.Skip((page - 1) * perPage).Take(perPage).ToListAsync(),
                    HasMore = (await results.CountAsync() - (((page - 1) * perPage) + perPage) >= 0),
                    Page = page,
                    PerPage = perPage
                };
            }
        }

        [HttpGet("{id}/GetDefendants")]
        public async Task<List<AccountSearchDefendant>> GetDefendantsByAccount(int id)
        {
            var account = await _context.Accounts.Include(x => x.Defendants).Where(x => x.AccountId == id).SingleOrDefaultAsync();

            if(account == null)
            {
                return new List<AccountSearchDefendant>();
            }

            return account.Defendants.Select(y => new AccountSearchDefendant { DefendantId = y.DefendantId, FullName = y.FullName }).ToList();
        }

    }

    public class AccountSearchDTO
    {
        public int AccountId { get; set; }
        public string Docket { get; set; }

        public List<AccountSearchDefendant> Defendants { get; set; }

        public List<MoneyOrdered> MoneyOrdered { get; set; }
        public LastPayment LastPayment { get; set; }

    }

    public class AccountSearchDefendant
    {
        public int DefendantId { get; set; }
        public string? FullName { get; set; }
    }

    public class MoneyOrdered
    {
        public decimal? FineAmount { get; set; }
        public decimal? RestitutionAmount { get; set; }
        public decimal? SurchargeAmount { get; set; }
        public decimal? MandatoryAmount { get; set; }
        public decimal? DWIAmount { get; set; }
        public decimal? MiscAmount { get; set; }
        public decimal? CVAFAmount { get; set; }
        public string? Notes { get; set; }
    }

    public class LastPayment
    {
        public int PaymentId { get; set; }
        public int? DefendantId { get; set; }
        public decimal? FineAmount { get; set; }
        public decimal? RestitutionAmount { get; set; }
        public decimal? SurchargeAmount { get; set; }
        public decimal? MandatoryAmount { get; set; }
        public decimal? DWIAmount { get; set; }
        public decimal? MiscAmount { get; set; }
        public decimal? CVAFAmount { get; set; }
        public decimal? EHMAnount { get; set; }
        public string? Notes { get; set; }
        public DateTime? Created { get; set; }
    }

    public class PaginationResultset
    {
        public List<AccountSearchDTO>? Results { get; set; }
        public List<AccountSearchDTO>? Options { get; set; }
        public bool HasMore { get; set; } = false;
        public int Page { get; set; }
        public int PerPage { get; set; }

    }
}
