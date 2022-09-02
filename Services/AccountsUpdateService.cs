using AutoMapper;
using SportReflections.Accounts.Api.DTOs;
using SportReflections.Accounts.Api.Models;
using SportReflections.Accounts.Api.Repository.Interfaces;
using SportReflections.Accounts.Api.Services.Interfaces;

namespace SportReflections.Accounts.Api.Services
{
    public class AccountsUpdateService : IUpdateAccountsService
    {
        readonly IMapper _mapper;
        readonly IUpdateAccounts _accountsRepository;

        public AccountsUpdateService(IMapper mapper, IUpdateAccounts accountsRepository)
        {
            _mapper = mapper;
            _accountsRepository = accountsRepository;
        }

        public async Task Update(int id, Account updatedAccount)
        {
            var updatedDto = _mapper.Map<AccountDTO>(updatedAccount);
            await _accountsRepository.Update(id, updatedDto);
        }
    }
}

