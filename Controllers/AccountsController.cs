using Microsoft.AspNetCore.Mvc;
using SportReflections.Accounts.Api.Models;
using SportReflections.Accounts.Api.Services.Interfaces;

namespace SportReflections.Accounts.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        readonly IAccountsService _accountService;

        public AccountsController(IAccountsService accountsService)
        {
            _accountService = accountsService;
        }

        [HttpGet]
        public async Task<IEnumerable<Account>> Get()
        {
            var accounts = await _accountService.Get();
            return accounts;
        }

        [HttpGet]
        [Route("/{id}")]
        public async Task<Account> Get(int id)
        {
            var account = await _accountService.Get(id);
            return account;
        }

        [HttpPost]
        [Route("/verify")]
        public async Task<Account> Get([FromBody] string email, [FromBody] string password)
        {
            //TODO: Hash password
            var hashedPassword = password;

            var account = await _accountService.Get(email, hashedPassword);
            return account;
        }

        [HttpPost]
        public async Task Create([FromBody] Account account)
        {
            await _accountService.Create(account);
        }

        [HttpPut]
        [Route("/{id}")]
        public async Task Update(int id, [FromBody] Account account)
        {
            await _accountService.Update(id, account);
        }
    }
}

