using AutoMapper;
using SportReflections.Accounts.Api.DTOs;
using SportReflections.Accounts.Api.Models;
using SportReflections.Accounts.Api.Repository.Interfaces;
using SportReflections.Accounts.Api.Services.Interfaces;

namespace SportReflections.Accounts.Api.Services
{
    public class AccountsCreatorService : ICreateAccountsService
    {
        private readonly IMapper _mapper;
        private readonly ICreateAccounts _accountRepository;

        public AccountsCreatorService(IMapper mapper, ICreateAccounts accountsRepository)
        {
            _mapper = mapper;
            _accountRepository = accountsRepository;
        }

        public async Task Create(Account account)
        {
            var accountDto = _mapper.Map<AccountDTO>(account);
            await _accountRepository.Create(accountDto);
        }
    }
}

