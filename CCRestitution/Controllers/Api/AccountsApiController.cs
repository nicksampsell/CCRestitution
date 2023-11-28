using CCRestitution.Data;
using CCRestitution.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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
        public async Task<List<AccountSearchDTO>> Search(string search)
        {
            return await _context.Accounts.Include(x => x.Defendants).Where(x => x.Defendants.Any(y => y.FirstName.Contains(search) || y.LastName.Contains(search)) || x.Docket.Contains(search)).Select(x => new AccountSearchDTO
            {
                AccountId = x.AccountId,
                Docket = x.Docket,
                Defendants = x.Defendants.Select(y => new AccountSearchDefendant { FullName = $"{y.FirstName} {y.MiddleName} {y.LastName}" }).ToList()
            }).ToListAsync();
        }

    }

    public class AccountSearchDTO
    {
        public int AccountId { get; set; }
        public string Docket { get; set; }

        public List<AccountSearchDefendant> Defendants { get; set; }

    }

    public class AccountSearchDefendant
    {
        public string FullName { get; set; }
    }
}
