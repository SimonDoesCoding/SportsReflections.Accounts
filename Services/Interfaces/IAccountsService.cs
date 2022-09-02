using SportReflections.Accounts.Api.Models;

namespace SportReflections.Accounts.Api.Services.Interfaces
{
    public interface IAccountsService : ICreateAccountsService, IGetAccountsService, IDeleteAccountsService, IUpdateAccountsService
    {

    }

    public interface ICreateAccountsService
    {
        Task Create(Account account);
    }

    public interface IGetAccountsService
    {
        Task<Account> Get(int id);
        Task<IEnumerable<Account>> Get();
        Task<Account> Get(string email, string password);
    }

    public interface IUpdateAccountsService
    {
        Task Update(int id, Account updatedAccount);
    }

    public interface IDeleteAccountsService
    {
        Task Delete(int id, bool isHardDelete = false);
    }
}