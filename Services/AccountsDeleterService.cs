using SportReflections.Accounts.Api.Repository.Interfaces;
using SportReflections.Accounts.Api.Services.Interfaces;

namespace SportReflections.Accounts.Api.Services
{
    public class AccountsDeleterService : IDeleteAccountsService
    {
        readonly IDeleteAccounts _accountsRepository;

        public AccountsDeleterService(IDeleteAccounts accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }

        public async Task Delete(int id, bool isHardDelete = false)
        {
            if (isHardDelete)
            {
                await _accountsRepository.HardDelete(id);
                return;
            }

            await _accountsRepository.SoftDelete(id);
        }
    }
}