using AutoMapper;
using SportReflections.Accounts.Api.Models;
using SportReflections.Accounts.Api.Repository.Interfaces;
using SportReflections.Accounts.Api.Services.Interfaces;

namespace SportReflections.Accounts.Api.Services
{
    public class AccountsGetterService : IGetAccountsService
    {
        private readonly IMapper _mapper;
        private readonly IGetAccounts _accountsRepository;

        public AccountsGetterService(IMapper mapper, IGetAccounts accountsRepository)
        {
            _mapper = mapper;
            _accountsRepository = accountsRepository;
        }

        public async Task<Account> Get(int id)
        {
            var accountDto = await _accountsRepository.Get(id);
            var account = _mapper.Map<Account>(accountDto);

            return account;
        }

        public async Task<IEnumerable<Account>> Get()
        {
            var accountDtos = await _accountsRepository.Get();
            var accounts = _mapper.Map<IEnumerable<Account>>(accountDtos);

            return accounts;
        }

        public async Task<Account> Get(string email, string password)
        {
            var accountDto = await _accountsRepository.Get(email, password);
            var account = _mapper.Map<Account>(accountDto);

            return account;
        }
    }
}

