using Models;
using System;
using Interfaces.Contexts;
using Interfaces.Repositories;

namespace Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IAccountContext Context;

        public AccountRepository(IAccountContext context)
        {
            Context = context;
        }

        public Account GetAccount(int id)
        {
            return Context.GetAccountByID(id);
        }
    }
}
