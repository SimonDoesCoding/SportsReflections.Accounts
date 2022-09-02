using Dapper;
using SportReflections.Accounts.Api.DTOs;
using SportReflections.Accounts.Api.Repository.Interfaces;
using SportReflections.Common.Interfaces;

namespace SportReflections.Accounts.Api.Repository
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly string _connectionString;
        private readonly IDbContext _dbContext;

        public AccountsRepository(IConfiguration config, IDbContext dbContext)
        {
            _connectionString = config.GetConnectionString("PostgresSQLConnectionString");
            _dbContext = dbContext;
        }

        public async Task Create(AccountDTO newAccount)
        {
            var query = "insert into Accounts values (@firstName, @lastName, @password, @passwordSalt)";

            using var connection = _dbContext.CreateConnection(_connectionString);
            await connection.ExecuteAsync(query, newAccount);
        }

        public async Task<AccountDTO> Get(int id)
        {
            var query = "select * from Accounts where id = @id and IsDeleted = 0";

            using var connection = _dbContext.CreateConnection(_connectionString);
            var account = await connection.QuerySingleOrDefaultAsync<AccountDTO>(query, new { id = id });

            return account;
        }

        public async Task<IEnumerable<AccountDTO>> Get()
        {
            var query = "select * from Accounts where IsDeleted = 0";

            using var connection = _dbContext.CreateConnection(_connectionString);
            var accounts = await connection.QueryAsync<AccountDTO>(query);

            return accounts;
        }

        public async Task<AccountDTO> Get(string email, string password)
        {
            var query = "select * from Accounts where email = @email and password = @password and IsDeleted = 0";

            using var connection = _dbContext.CreateConnection(_connectionString);
            var account = await connection.QuerySingleOrDefaultAsync<AccountDTO>(query, new { email, password });

            return account;
        }

        public async Task HardDelete(int id)
        {
            var query = "delete from Account where id = @id";

            using var connection = _dbContext.CreateConnection(_connectionString);
            await connection.ExecuteAsync(query, new { id });
        }

        public async Task SoftDelete(int id)
        {
            var query = "update Accounts set IsDeleted = 1 where id = @id";

            using var connection = _dbContext.CreateConnection(_connectionString);
            await connection.ExecuteAsync(query, new { id });
        }

        public async Task Update(int id, AccountDTO updatedAccount)
        {
            var query = @"
                update Accounts
                set FirstName = @firstName
                    ,LastName = @lastName
                    ,Email = @email
                    ,Password = @password
                where id = @id";

            using var connection = _dbContext.CreateConnection(_connectionString);
            await connection.ExecuteAsync(query, updatedAccount);
        }
    }
}

