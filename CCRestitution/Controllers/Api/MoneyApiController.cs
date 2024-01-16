using CCRestitution.Data;
using CCRestitution.Interfaces;
using CCRestitution.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Pagination.EntityFrameworkCore.Extensions;
using System.Collections.Generic;

namespace CCRestitution.Controllers.Api
{
    [Route("api/Money")]
    [ApiController]
    public class MoneyApiController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMoneyService _moneyService;

        public MoneyApiController(DataContext context, IMoneyService moneyService)
        {
            _context = context;
            _moneyService = moneyService;
        }

        [HttpGet("MoneyOrderedByAccount/{id}")]
        public async Task<Object> MoneyStatusByAccount(int id)
        {
            var mo = await _context.MoneyOrdered.Where(x => x.AccountId == id).FirstOrDefaultAsync();

            if (mo == null)
            {
                return BadRequest();
            }

            return new MoneyServiceDTO
            {
                FineAmount = mo.FineAmount,
                FineBalance = mo.FineBalance,
                MandatoryAmount = mo.MandatoryAmount,
                MandatoryBalance = mo.MandatoryBalance,
                EHMAmount = mo.CVAFAmount,
                EHMBalance = mo.CVAFBalance,
                RestitutionAmount = mo.RestitutionAmount,
                RestitutionBalance = mo.RestitutionBalance,
                SurchargeAmount = mo.SurchargeAmount,
                SurchargeBalance = mo.SurchargeBalance,
                MiscAmount = mo.MiscAmount,
                MiscBalance = mo.MiscBalance,
                SupvAmount = null,
                SupvBalance = null
            };
            
        }

    }

    public class MoneyServiceDTO
    {
        public decimal? FineAmount { get; set; }
        public decimal? FineBalance { get; set; }
        public decimal? MandatoryAmount { get; set; }
        public decimal? MandatoryBalance { get; set; }
        public decimal? EHMAmount { get; set; }
        public decimal? EHMBalance { get; set; }
        public decimal? RestitutionAmount { get; set; }
        public decimal? RestitutionBalance { get; set; }
        public decimal? SurchargeAmount { get; set; }
        public decimal? SurchargeBalance { get; set; }
        public decimal? MiscAmount { get; set; }
        public decimal? MiscBalance { get; set; }
        public decimal? SupvAmount { get; set; }
        public decimal? SupvBalance { get; set; }
    }

   
}
