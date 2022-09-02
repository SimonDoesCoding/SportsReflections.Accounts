using SportReflections.Accounts.Api.DTOs;

namespace SportReflections.Accounts.Api.Repository.Interfaces
{
    public interface IAccountsRepository : IGetAccounts, ICreateAccounts, IUpdateAccounts, IDeleteAccounts
    {
    }

    public interface IGetAccounts
    {
        Task<AccountDTO> Get(int id);
        Task<IEnumerable<AccountDTO>> Get();
        Task<AccountDTO> Get(string email, string password);
    }

    public interface ICreateAccounts
    {
        Task Create(AccountDTO newAccount);
    }

   public interface IUpdateAccounts
    {
        Task Update(int id, AccountDTO updatedAccount);
    }

    public interface IDeleteAccounts
    {
        Task SoftDelete(int id);
        Task HardDelete(int id);
    }
}

